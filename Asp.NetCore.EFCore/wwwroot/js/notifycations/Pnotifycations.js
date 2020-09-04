
/*
	Positions
	*/
var stack_topleft = { "dir1": "down", "dir2": "right", "push": "top" };
var stack_bottomleft = { "dir1": "right", "dir2": "up", "push": "top" };
var stack_bottomright = { "dir1": "up", "dir2": "left", "firstpos1": 15, "firstpos2": 15 };
var stack_bar_top = { "dir1": "down", "dir2": "right", "push": "top", "spacing1": 0, "spacing2": 0 };
var stack_bar_bottom = { "dir1": "up", "dir2": "right", "spacing1": 0, "spacing2": 0 };

//右上方，点击关闭，成功
function ClickToCloseTopRightSuccess(msg) {
    var notice = new PNotify({
        title: '点击关闭',
        text: msg,
        type: 'success',
        addclass: 'click-2-close',
        hide: false,
        buttons: {
            closer: false,
            sticker: false
        }
    });

    notice.get().click(function () {
        notice.remove();
    });
}

//点击关闭 右上方，Erro
function ClickToCloseTopRightErro(msg) {
    var notice = new PNotify({
        title: '点击关闭',
        text: msg,
        type: 'error',
        addclass: 'click-2-close',
        hide: false,
        buttons: {
            closer: false,
            sticker: false
        }
    });

    notice.get().click(function () {
        notice.remove();
    });
}


//底部，成功
function ClickToCloseBottomSuccess() {
    var notice = new PNotify({
        title: 'Notification',
        text: 'Some notification text.',
        type: 'success',
        addclass: 'stack-bar-bottom',
        stack: stack_bar_bottom,
        width: "70%"
    });

    notice.get().click(function () {
        notice.remove();
    });
}

//底部，erro
function ClickToCloseBottomErro() {
    var notice = new PNotify({
        title: 'Notification',
        text: 'Some notification text.',
        type: 'success',
        addclass: 'stack-bar-bottom',
        stack: stack_bar_bottom,
        width: "70%"
    });

    notice.get().click(function () {
        notice.remove();
    });
}