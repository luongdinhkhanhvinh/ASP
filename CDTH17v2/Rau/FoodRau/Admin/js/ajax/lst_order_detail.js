$(this).ready(function () {
    getList();
});

function getList() {
    var key = $('#hfOrderId').val();
    if (key == "") {
        return;
    }
    $.ajax({
        url: 'lst_order_detail.aspx/searchCode',
        type: "post",
        data: "{key:'" + key + "'}",
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
        table += "<td>" + (Number(i)+1) + "</td>";
        table += "<td>" + obj[i].Name + "</td>";
        table += "<td>" + obj[i].Quan + "</td>";
        table += "<td>" + obj[i].Unit + "</td>";
        table += "<td>" + obj[i].Price + "</td>";
        table += "<td>" + obj[i].Total + "</td>";
        table += "</tr>";
    }
    $('.rptDS').html(table);
}
