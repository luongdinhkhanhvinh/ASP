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
        return !($('#cph_content_lblErrorUserName').text().length > 0 || $('#cph_content_lblErrorEmail').text().length > 0 || $('#cph_content_lblErrorSDT').text().length > 0);
    }
    return true;
}

function search(page) {
    var key = $('.txtSearch').val();
    $.ajax({
        url: 'member.aspx/searchCode',
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

function existUserName() {
    if (!checkUpdate) {
        $.ajax({
            type: 'post',
            url: "member.aspx/existUser",
            data: "{username:'" + $('.txtUser').val() + "'}",
            contentType: 'application/json;charset=utf-8',
            success: function (response) {
                if (response.d) {
                    $('#cph_content_lblErrorUserName').text("Đã tồn tại");
                } else {
                    $('#cph_content_lblErrorUserName').text("");
                }
            },
            error: function (err) {
                alert("error" + err.d);
            }
        });
    }
}

function existEmail() {
    if (!checkUpdate) {
        $.ajax({
            type: 'post',
            url: "member.aspx/existE",
            data: "{email:'" + $('.txtEmail').val() + "'}",
            contentType: 'application/json;charset=utf-8',
            success: function (response) {
                if (response.d) {
                    $('#cph_content_lblErrorEmail').text("Đã tồn tại");
                } else {
                    $('#cph_content_lblErrorEmail').text("");
                }
            },
            error: function (err) {
                alert("error" + err.d);
            }
        });
    }
}

function existSDT() {
    if (!checkUpdate) {
        $.ajax({
            type: 'post',
            url: "member.aspx/existS",
            data: "{sdt:'" + $('.txtSDT').val() + "'}",
            contentType: 'application/json;charset=utf-8',
            success: function (response) {
                if (response.d) {
                    $('#cph_content_lblErrorSDT').text("Đã tồn tại");
                } else {
                    $('#cph_content_lblErrorSDT').text("");
                }
            },
            error: function (err) {
                alert("error" + err.d);
            }
        });
    }
}

function Chon(username) {
    $.ajax({
        type: 'post',
        url: "member.aspx/getObject",
        data: "{username:'" + username + "'}",
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

function xoa(username) {
    $('#cph_content_lblMessage').text("Bạn có muốn xóa?");
    $('#cph_content_hfUserNameConfirm').val(username);
    $('.btnConfỉrm').show();
    showModal();
}

function xacNhanXoa() {
    var username = $('#cph_content_hfUserNameConfirm').val();
    $.ajax({
        type: 'post',
        url: "member.aspx/setStatusdelete",
        data: "{username:'" + username + "'}",
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
    $('#cph_content_txtUserName').val(obj.UserName);
    $('#cph_content_hfUserName').val(obj.UserName);
    $('#cph_content_txtName').val(obj.Name);
    $('#cph_content_txtEmail').val(obj.Email);
    $('#cph_content_txtPhone').val(obj.Phone);
    $('#cph_content_ddlRole').val(obj.Role);
    $('#cph_content_ddlStatus').val(obj.Status);
}

function clearError() {
    $('.tbError').text('');
}

function resetList(lst_json) {
    var obj = lst_json["obj"];
    var table = "";
    for (i = 0; i < obj.length; i++) {
        table += "<tr>"
        table += "<td>" + obj[i].UserName + "</td>";
        table += "<td>" + obj[i].Name + "</td>";
        table += "<td>" + obj[i].Email + "</td>";
        table += "<td>" + obj[i].Phone + "</td>";
        table += "<td><input type='checkbox'" + ((obj[i].Role > 0) ? 'checked' : '') + " disabled /></td>";
        table += "<td><input type='checkbox'" + ((obj[i].Status > 0) ? 'checked' : '') + " disabled /></td>";
        table += "<td><a href='#chon'><img id='imgHinh' alt='' width='20' height='20' src='/Admin/icon/edit.png' onClick='Chon(" + "\"" + obj[i].UserName + "\"" + ");'/></a>";
        table += "<a href='#dataTable1'><img id='imgHinh' alt='' width='20' height='20' src='/Admin/icon/delete.png' onClick='xoa(" + "\"" + obj[i].UserName + "\"" + ");'/></a></td>";
        table += "</tr>";
    }
    $('.rptDS').html(table);
    //2 cái này là sao 
    //ông nhớ phân trang nó có 1 cái để in vị trí paging. 1 cái để active khi nhấn vô.
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
    $('#cph_content_rfvUserName').css("visibility", "hidden");
    $('#cph_content_txtUserName').prop("disabled", check);
    $('#cph_content_btn_register').prop("disabled", check);
    $('#cph_content_btn_update').prop("disabled", !check);
    $('.btnConfỉrm').hide();
}

