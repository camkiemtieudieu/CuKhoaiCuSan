//khai báo hai đối tượng button và content của tab ứng với button
var button = document.getElementsByClassName("tablink");
var contents = document.getElementsByClassName("content");


//hàm show nội dung khi button kích hoạt
function ShowContent(id) {
    //ẩn nội dung //.length xác định số lượng phần tử trong trang 
    for (var i = 0; i < contents.length; i++) {
        //an content cac tab
        contents[i].style.display = 'none'
        //this.style.color = inherit;
      //  contents[i].
    }
    // khai báo đối tượng nội dụng theo id
    var content = document.getElementById(id);
    content.style.display = 'block';
    //this.style.color = 'palevioletred';
}
//vòng for lắng nghe sự kiện kiện
for (var j = 0; j < button.length; j++) {
   // button[j].style.color = 'red';
    button[j].addEventListener("click", function () {
        //for (var k = 0; k < button.length; j++) {
        //    button[k].style.color = 'black';
        //}
        var id = this.textContent;
        this.style.color = 'palevioletred';
        //for (var i = 0; i < button.length; i++) {
        //    button[i].classList.remove("active");
        //}
        //this.className += " active";
        ShowContent(id);
    });
}

ShowContent('PHP')

