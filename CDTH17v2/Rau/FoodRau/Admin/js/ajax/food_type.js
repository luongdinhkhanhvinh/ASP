var checkUpdate = false;

$(this).ready(function () {
    search(1);
    checkEnable(false);
    initValidator();
});

function initValidator() {
    this.checkUpdate = false;
}

function Valid() {
   
    if (Page_ClientValidate('vsNotification')) {
        return !($('#cph_content_lblErrorName').text().length > 0 || $('#cph_content_hfNameImg').val() == "");
    }
    return true;
}

function search(page) {
    var key = $('.txtSearch').val();
    $.ajax({
        url: 'food_type.aspx/searchCode',
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

function existName() {
    if (!checkUpdate) {
        $.ajax({
            type: 'post',
            url: "food_type.aspx/existN",
            data: "{type_name:'" + $('.txtName').val() + "'}",
            contentType: 'application/json;charset=utf-8',
            success: function (response) {
                if (response.d) {
                    $('#cph_content_lblErrorName').text("Đã tồn tại");
                } else {
                    $('#cph_content_lblErrorName').text("");
                }
            },
            error: function (err) {
                alert("error" + err.d);
            }
        });
    }
}

function Chon(type_id) {
    $.ajax({
        type: 'post',
        url: "food_type.aspx/getObject",
        data: "{type_id:'" + type_id + "'}",
        contentType: 'application/json;charset=utf-8',
        success: function (response) {
            setValues(response.d);
            checkEnable(true);
            clearError();
        },
        error: function (err) {
            alert("error" + err.d);
        }
    });
}

function xoa(type_id) {
    $('#cph_content_lblMessage').text("Bạn có muốn xóa?");
    $('#cph_content_hfUserNameConfirm').val(type_id);
    $('.btnConfỉrm').show();
    showModal();
}

function xacNhanXoa() {
    var type_id = $('#cph_content_hfUserNameConfirm').val();
    $.ajax({
        type: 'post',
        url: "food_type.aspx/setStatusdelete",
        data: "{type_id:'" + type_id + "'}",
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

function setValues(obj) {
    $('#cph_content_hfTypeID').val(obj.Type_id);
    $('#cph_content_txtName').val(obj.Type_name);
    $('#cph_content_txtPost').val(obj.Type_post);
    $('#cph_content_imgReview').attr('src', "../Uploads/Images/" + obj.Type_img);
    $('#cph_content_hfNameImg').val(obj.Type_img);
    $('#cph_content_ddlStatus').val(obj.Status);
}

function clearError() {
    $('.tbError').text('');
    $('.lblThongBao').text('');
}

function resetList(lst_json) {
    var obj = lst_json["obj"];
    var table = "";
    for (i = 0; i < obj.length; i++) {
        table += "<tr>"
        table += "<td>" + obj[i].Type_id    + "</td>";
        table += "<td>" + obj[i].Type_name  + "</td>";
        table += "<td>" + obj[i].Type_post  + "</td>";
        table += "<td><img id='imgHinh' alt='' width='50' height='50' src='../Uploads/Images/" + obj[i].Type_img + "' /></td>";
        table += "<td><input type='checkbox'" + ((obj[i].Status > 0) ? 'checked' : '') + " disabled /></td>";
        table += "<td>" + moment(obj[i].Modified).format('MM/DD/YYYY')+"</td>";

        table += "<td><a href='#chon'><img id='imgHinh' alt='' width='20' height='20' src='/Admin/icon/edit.png' onClick='Chon(" + "\"" + obj[i].Type_id + "\"" + ");'/></a>";
        table += "<a href='#chon'><img id='imgHinh' alt='' width='20' height='20' src='/Admin/icon/delete.png' onClick='xoa(" + "\"" + obj[i].Type_id + "\"" + ");'/></a></td>";
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

function checkEnable(check) {
    this.checkUpdate = check;
    $('#cph_content_btnThem').prop("disabled", check);
    $('#cph_content_btnCapNhat').prop("disabled", !check);
    $('.btnConfỉrm').hide();
}

