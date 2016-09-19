var timer;
var wait = 5; //กำหนดเวลาในหน่วย นาที
var redirectPage = 'Logout.aspx'; //หน้าที่ต้องการให้ logOut

document.onkeypress = resetTimer;

document.onmousemove = resetTimer;

function resetTimer() {

    clearTimeout(timer);
    timer = setTimeout("logout()", 60000 * wait);
}

function logout() {
    //Change Refrshe
    //window.location.href = redirectPage;
    window.location.reload();

}