$(this).ready(function () {
    search(1);
});


function search(page) {
    var key = $('.txtSearch').val();
    $.ajax({
        url: 'lst_post.aspx/searchCode',
        type: "post",
        data: "{key:'" + key + "',page:'" + page + "'}",
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            resetList(JSON.parse(response.d));
        },
        error: function (error) {
            alert(error.d);
        }
    });
}

function resetList(lst_json) {
    var obj = lst_json["obj"];
    var table = "";
    for (i = 0; i < obj.length; i++) {
        table += "<tr>"
        table += "<td>" + obj[i].Post_id + "</td>";
        table += "<td><a href='/Home/blog-single.aspx?post_id=" + obj[i].Post_id + "'>" + obj[i].Title + "</a>";
        table += "<td>" + obj[i].Short + "</td>";
        table += "<td><a href='/Home/blog.aspx?type=" + obj[i].Type + "'>" + obj[i].Type_name + "</a>";
        table += "<td><a href='post.aspx?post_id=" + obj[i].Post_id + "'><img id='imgHinh' alt='' width='20' height='20' src='/Admin/icon/edit.png'/></a>";
        table += "<a href='#dataTable1'><img id='imgHinh' alt='' width='20' height='20' src='/Admin/icon/delete.png' onClick='xoa(" + "\"" + obj[i].Post_id + "\"" + ");'/></a></td>";
        table += "</tr>";
    }
    $('.rptDS').html(table);
    var index = lst_json["record"];
    var active = lst_json["active"];
    var result = "";
    for (var i = 0; i < index.length; i++) {
        var stt = (Number(index[i]) + 1);
        var current = ((Number(active[i])) == 1 ? 'active' : '');
        result += "<li class='paginate_button page-item " + current + "'>";
        result += "<input  class='page-link' type='button' value='" + stt + "' onclick='search(" + stt + ")'/>";
        result += "</li>";
    }
    $('.record').html(result);
}

function xoa(id) {
    $('#cph_content_lblMessage').text("Bạn có muốn xóa?");
    $('#cph_content_hfUserNameConfirm').val(id);
    $('.btnConfỉrm').show();
    showModal();
}

function xacNhanXoa() {
    var id = $('#cph_content_hfUserNameConfirm').val();
    $.ajax({
        type: 'post',
        url: "lst_post.aspx/setStatusdelete",
        data: "{id:'" + id + "'}",
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            if (response.d) {
                search(1);
                $("#myModal").modal('hide');
            } else {
                alert("Xóa Thất Bại");
            }

        },
        error: function (err) {
            alert("error" + err.d);
        }
    });
}
