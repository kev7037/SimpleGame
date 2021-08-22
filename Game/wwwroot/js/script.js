let COUNTER_START_VALUE = 3;
var globTimeLeft = 3;
var counter = 10;
var game_guid = '';
var intervalHolder;
var topPosition = 0;
var ids = [];
var correctAnswerCount = 0;
var correctAnswerPoint = 20;
var wrongAnswerPoint = -5;
var TotalPoints = 0;
var correctAnswer = 0;

start_game();

function guess(choice) {

    debugger
    if (!(isNumeric(choice) && choice > -1 && choice < 5)) {
        /* 0: no answer
        ** 1: Japanese
        ** 2: Chinese
        ** 3: Korean
        ** 4: Thai
        */
        window.alert('wrong input!');
        return;
    }

    if ((isNumeric(choice) && choice > 0 && choice < 5) && globTimeLeft > 0) {

        disableButtons();

        clearInterval(intervalHolder);
        move_box_to_answer(choice, 'pageBeginCountdown', 'pageBeginCountdownText');
        return;
    } else if (choice < 0 || choice > 5) {
        hide_move_box();
        window.alert('wrong input!');
        return;

    } else if (counter == 0) {
        //finished
        calculatePoints(choice);
        finish_game();
    } else {
        hide_move_box();
        calculatePoints(choice);

        var rand = 0;

        do {
            rand = Math.floor(Math.random() * (13 - 1 + 1)) + 1;
        } while (ids.indexOf(rand) >= 0)

        ids.push(rand);

        var url = '/Home/NextImage?id=' + rand;
        $.get(url, function (result) {

            if (!result.isSuccess) {
                window.alert('something went wrong. Please reload the page to start over.');
                return;
            }
            counter--;
            next_level(result.data);
        });
    }
}

function isNumeric(value) {
    return /^-?\d+$/.test(value);
}

function next_level(data) {

    $("#img_to_guess").attr("src", data.imgUrl);

    $("#img_holder_div").css("top", '10%');
    $("#img_holder_div").css("left", '40%');

    correctAnswer = parseInt(data.answer);

    restart_timer();
    enableButtons();
}

function finish_game() {
    showResult();
}

function start_game() {

    var rand = 0;

    do {
        rand = Math.floor(Math.random() * (13 - 1 + 1)) + 1;
    } while (ids.indexOf(rand) >= 0)

    ids.push(rand);

    var url = '/Home/NextImage?id=' + rand;
    $.get(url, function (result) {

        if (!result.isSuccess) {
            window.alert('something went wrong. Please reload the page to start over.');
            return;
        }
        counter--;
        next_level(result.data);
    });
}

function restart_timer() {
    globTimeLeft = 3;
    clearInterval(intervalHolder);
    ProgressCountdown(COUNTER_START_VALUE, 'pageBeginCountdown', 'pageBeginCountdownText');
}

function ProgressCountdown(timeleft, bar, text) {
    return new Promise((resolve, reject) => {
        var countdownTimer = setInterval(() => {
            if (timeleft == COUNTER_START_VALUE) {
                show_move_box();
            }
            debugger
            timeleft -= 0.25;
            globTimeLeft -= 0.25;
            move_img_box();

            document.getElementById(bar).value = timeleft;
            document.getElementById(text).textContent = timeleft;

            if (timeleft <= 0) {
                clearInterval(countdownTimer);
                resolve(true);
                guess(0);

            }
        }, 250);
        intervalHolder = countdownTimer;
    });
}

function move_img_box() {
    $("#img_holder_div").css("top", '' + topPosition + '%');
    topPosition += 2;
}

function move_img_box_to_choice(choice) {

    var topLocal = $("#img_holder_div").css("top").split('px')[0].split('.')[0];
    var leftLocal = $("#img_holder_div").css("left").split('px')[0].split('.')[0];

    var remainingIterations = COUNTER_START_VALUE / 0.25;

    switch (choice) {
        case 1:
            var btn1Top = $('#Btn_Japanese').offset().top;
            var btn1Left = $('#Btn_Japanese').offset().left;

            topLocal = (parseInt(topLocal) - ((Math.abs(parseInt(topLocal) - btn1Top) / remainingIterations)));
            leftLocal = (parseInt(leftLocal) - ((Math.abs(parseInt(leftLocal) - btn1Left) / remainingIterations)));
            break;

        case 2:
            var btn2Top = $('#Btn_Chinese').offset().top;
            var btn2Left = $('#Btn_Chinese').offset().left;

            topLocal = (parseInt(topLocal) - ((Math.abs(parseInt(topLocal) - btn2Top) / remainingIterations)));
            leftLocal = (parseInt(leftLocal) + ((Math.abs(parseInt(leftLocal) - btn2Left) / remainingIterations)));
            break;
        case 3:

            var btn3Top = $('#Btn_Korean').offset().top;
            var btn3Left = $('#Btn_Korean').offset().left;

            topLocal = (parseInt(topLocal) + ((Math.abs(parseInt(topLocal) - btn3Top) / remainingIterations)));
            leftLocal = (parseInt(leftLocal) - ((Math.abs(parseInt(leftLocal) - btn3Left) / remainingIterations)));
            break;

        case 4:
            var btn4Top = $('#Btn_Thai').offset().top;
            var btn4Left = $('#Btn_Thai').offset().left;

            topLocal = (parseInt(topLocal) + ((Math.abs(parseInt(topLocal) - btn4Top) / remainingIterations)));
            leftLocal = (parseInt(leftLocal) + ((Math.abs(parseInt(leftLocal) - btn4Left) / remainingIterations)));
            break;

        default:
            window.alert('something went wrong');
            break;
    }

    $("#img_holder_div").css("top", '' + topLocal + 'px');
    $("#img_holder_div").css("left", '' + leftLocal + 'px');

}

function hide_move_box() {
    $("#img_holder_div").css("display", 'none');
}

function show_move_box() {
    topPosition = 20;
    $("#img_holder_div").css("display", 'inherit');
}

function move_box_to_answer(choice, bar, text) {
    var countdownTimer2 = setInterval(() => {

        move_img_box_to_choice(choice);

        globTimeLeft -= 0.25;


        document.getElementById(bar).value = globTimeLeft;
        document.getElementById(text).textContent = globTimeLeft;

        if (globTimeLeft <= 0) {
            clearInterval(countdownTimer2);
            guess(choice);

        }
    }, 250);
    intervalHolder = countdownTimer2;
}

function enableButtons() {
    $('#Btn_Japanese').prop('disabled', false);
    $('#Btn_Chinese').prop('disabled', false);
    $('#Btn_Korean').prop('disabled', false);
    $('#Btn_Thai').prop('disabled', false);
}

function disableButtons() {
    $('#Btn_Japanese').prop('disabled', true);
    $('#Btn_Chinese').prop('disabled', true);
    $('#Btn_Korean').prop('disabled', true);
    $('#Btn_Thai').prop('disabled', true);
}

function showResult() {
    $("#GamePage").css('display', 'none');
    $("#ResultPage").css('display', 'inherit');

    $("#TotalPoints").html(TotalPoints);
    $("#TotalCorrectAnswersSpan").html(correctAnswerCount);
}

function calculatePoints(choice) {

    if (parseInt(choice) == parseInt(correctAnswer)) {
        TotalPoints = parseInt(TotalPoints) + parseInt(correctAnswerPoint);
        correctAnswerCount++;
        $('#score_div').css('background-color', 'green');
    } else {
        TotalPoints = parseInt(TotalPoints) + parseInt(wrongAnswerPoint);
        $('#score_div').css('background-color', 'red');
    }

    $('#score_span').html(TotalPoints);
}