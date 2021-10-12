

$(document).ready(function () {
    debugger;
    var PrabhagListNo = $('#PrabhagList').val();
    $.ajax({
        type: "post",
        url: "/PTC/PrabhagList",
        data: { userId: PrabhagListNo },
        datatype: "json",
        traditional: true,
        success: function (data) {
            district = '<option value="-1">Select Prabhag No.</option>';
            district = '<option value="All">Select All.</option>';
            for (var i = 0; i < data.length; i++) {
                district = district + '<option value=' + data[i].Value + '>' + data[i].Text + '</option>';
            }
            //district = district + '</select>';
            $('#PrabhagList').html(district);
        }
    });


    var WardListNo = $('#WardList').val();
    $.ajax({
        type: "post",
        url: "/PTC/WardList",
        data: { userId: WardListNo },
        datatype: "json",
        traditional: true,
        success: function (data) {
            district = '<option value="-1">Select Ward No.</option>';
            district = '<option value="All">Select All.</option>';
            for (var i = 0; i < data.length; i++) {
                district = district + '<option value=' + data[i].Value + '>' + data[i].Text + '</option>';
            }
            //district = district + '</select>';
            $('#WardList').html(district);
        }
    });

    var WardListNo = $('#CSDate').val();
    $.ajax({
        type: "post",
        url: "/PTC/CSDateList",
        data: { userId: WardListNo },
        datatype: "json",
        traditional: true,
        success: function (data) {
            district = '<option value="-1">Select Cons.Start Date.</option>';
            district = '<option value="All">Select All.</option>';
            for (var i = 0; i < data.length; i++) {
                district = district + '<option value=' + data[i].Value + '>' + data[i].Text + '</option>';
            }
            //district = district + '</select>';
            $('#CSDate').html(district);
        }
    });

    var WardListNo = $('#CEDate').val();
    $.ajax({
        type: "post",
        url: "/PTC/CEDateList",
        data: { userId: WardListNo },
        datatype: "json",
        traditional: true,
        success: function (data) {
            district = '<option value="-1">Select Cons.End Date.</option>';
            district = '<option value="All">Select All.</option>';
            for (var i = 0; i < data.length; i++) {
                district = district + '<option value=' + data[i].Value + '>' + data[i].Text + '</option>';
            }
            //district = district + '</select>';
            $('#CEDate').html(district);
        }
    });

    $("#SearchText").val("");
    $("#para").show().delay(3000).show().fadeOut('slow');
    /* document.getElementById("para").reset();*/


    //var msg = document.getElementById("para").textContent;
    //if (msg == 'This Massage Is  Send Successfully!') {

    //    var x = document.getElementById("snackbar");
    //    x.className = "show";
    //    setTimeout(function () { x.className = x.className.replace("show", ""); }, 4000);
    //    document.getElementById('para').textContent = ''
    //}

    ActiveEmployee();

    $("#SearchText").change(function () {
        debugger;

        var SearchText = $("#SearchText").val();
        // var selectoption = $("#selectoption").value();
        var selectoption = $('input[type=radio][name=selectoption]:checked').attr('id');
        $.ajax({
            url: "/PTC/SelectionNotExists?SearchText=" + SearchText + "&selectoption=" + selectoption + "",
            type: "POST",
            data: { SearchText: SearchText }
        })
            .done(function (msg) {

                $('#err_PropertyNo').text(msg);

            });
    });


});
//function SendRemainder(q) {
//    debugger;


//    $.ajax({
//        url: "/PTC/SurveyList?q=" + q + "&selectoption=PropertyNumber&Reminder=Reminder",
//        type: "POST",

//        dataType: 'json',
//        contentType: false,
//        processData: false,
//        success: function (response) {
//            debugger;
//            if (response.success) {


//                $('#demoModalSuccess').modal('show');
//            } else {

//                $('#demoModalError').modal('show');
//            }
//        },
//        error: function (response) {
//            alert("error!");  
//        }

//    });
//}

function send() {
    debugger
    //var msg = document.getelementbyid("para").textcontent;
    //if (msg == 'this massage is  send successfully!') {
    //    var startInterval/*in milliseconds*/ = Math.floor(Math.random() * 30) * 1000;
    //    var x = document.getelementbyid("snackbar");
    //    x.classname = "show";
    //    settimeout(function () { x.classname = x.classname.replace("show"); }, startInterval);

    //}
    //else {
    //    $('#demomodalerror').modal('show');
    //}
    $('#para').css('display', 'block')
    //$("#para").show().delay(3000).show().fadeOut('slow').css("background-color", "yellow");

}
function SendRemainder(q) {
    debugger;


    $.ajax({
        url: "/PTC/SurveyList?q=" + q + "&selectoption=PropertyNumber&Reminder=Reminder",
        type: "POST",

        dataType: 'json',
        contentType: false,
        processData: false,
        success: function (response) {
            if (response.success) {
                var x = document.getElementById("snackbar");
                x.className = "show";
                setTimeout(function () { x.className = x.className.replace("show", ""); }, 4000);
            } else {
                var x = document.getElementById("snackbar1");
                x.className = "show";
                setTimeout(function () { x.className = x.className.replace("show", ""); }, 4000);
            }
        },
        error: function (response) {
            alert("error!");
        }

    });
}

function Bill(q) {
    debugger;


    $.ajax({
        url: "/PTC/SurveyList?q=" + q + "&selectoption=PropertyNumber&send=send",
        type: "POST",
        dataType: 'json',
        contentType: false,
        processData: false,
        success: function (response) {
            debugger;
            if (response.success) {
                var x = document.getElementById("snackbar");
                x.className = "show";
                setTimeout(function () { x.className = x.className.replace("show", ""); }, 4000);
            } else {
                var x = document.getElementById("snackbar1");
                x.className = "show";
                setTimeout(function () { x.className = x.className.replace("show", ""); }, 4000);
            }
        },
        error: function (response) {
            alert("error!");  // 
        }

    });
}


$(function () {
    $("#btnShow").click(function () {
        $('#demoModal').modal('show');
    });

    $("#btnSearch").click(function () {
        $('#demoModalSearch').modal('show');
    });
});
function Edit(ID) {

    window.location.href = "/PTC/SurveyForm?q=" + ID;
}


function View(ID) {
    window.location.href = "/PTC/ViewSurveyForm?q=" + ID;
}
var url;
function Download(ID) {
    debugger;

    url = "/PTC/ViewSurveyForm?q=" + ID;

    var myWindow;
    myWindow = window.open(url, "myWindow", "_blank", 'fullscreen=yes');
    myWindow.print();
    var blob = new Blob([myWindow], { type: "application/octetstream" });
    // myWindow.close();
    //  link = url.createObjectURL(blob);
    //   myWindow.remove(url);
}

function DownloadQRCode(q) {
    debugger;
    window.location.href = "/PTC/Export?q=" + q;
};


function closeWin() {
    myWindow.close();
}

function capitalize_Words(str) {
    debugger;
    return str.replace(/\w\S*/g, function (txt) { return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase(); });
}
//console.log(capitalize_Words('js string exercises'));


const uppercaseWords = str => str.replace(/^(.)|\s+(.)/g, c => c.toUpperCase());
function ActiveEmployee() {

    function format(d) {
        var result = '<table id="childtable" cellpadding="5" cellspacing="0" border="0" style="padding-left: 50px; width:80% ">' +
            '<tr><td>Kimlik No</td><td>Product Detail</td><td>Product Color</td><td>Product Quantity</td></tr>';
        //loop thouth the OderListDetails and add the child items.
        for (var i = 0; i < d.orderListDetails.length; i++) {
            var child = '<tr><td>' + d.orderListDetails[i].kimlikId + '</td>' +
                '<td>' + d.PropOwnerTelephoneNo + '</td>' +
                '<td>' + d.NewPropertyNo + '</td>' +
                '<td>' + d.PropertyNo + '</td></tr>';
            result += child;
        }
        result += '</table>';
        return result;
    }
    $(document).ready(function () {
        //call the action method and get the data.
        $.ajax({
            url: "/PTC/LoadData/",
            type: "Get",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                console.log("succsss" + data);
                //after getting the data, bind the DataTable.
                var table = $("#example").DataTable({
                    "data": data,
                    "columns": [
                        {
                            "className": 'details-control',
                            "orderable": false,
                            "data": null,
                            "defaultContent": ''
                        },
                        { "data": "PrabhagNo" },
                        { "data": "WardName_No" },
                        { "data": "ConstStartYear" },
                        { "data": "CompletionYear" },
                    ],
                    "order": [[0, 'desc']]
                });

                //Expand/Collapse the nested objects.
                $('#example tbody').on('click', 'td.details-control', function () {
                    var tr = $(this).closest('tr');
                    var row = table.row(tr);

                    if (row.child.isShown()) {
                        // This row is already open - close it
                        row.child.hide();
                        tr.removeClass('shown');
                    }
                    else {
                        // Open this row
                        row.child(format(row.data())).show();
                        tr.addClass('shown');
                    }
                });
            },
            error: function (ex) {
                console.log(ex);
            }
        });
    });

}



const ui = {
    confirm: async (message) => createConfirm(message)
}

const createConfirm = (message) => {
    return new Promise((complete, failed) => {
        $('#confirmMessage').text(message)

        $('#confirmYes').off('click');
        $('#confirmNo').off('click');

        $('#confirmYes').on('click', () => { $('.confirm').hide(); complete(true); });
        $('#confirmNo').on('click', () => { $('.confirm').hide(); complete(false); });

        $('.confirm').show();
    });
}

const Delete = async (ID) => {
    const confirm = await ui.confirm('Are you sure you want to Delete?');

    if (confirm) {
        window.location.href = "/PTC/Delete?q=" + ID;
        return true;
    } else
        return false;
}




//var func_count = 1
//setInterval(function () {
//    notification_count()
//}, 35000
//);



//function Delete(ID) {
//    // return confirm('Are you sure you want to Delete?')
//    var x = confirm("Are you sure you want to delete?");
//    if (x) {
//        window.location.href = "/PTC/Delete?q=" + ID;
//        return true;
//    }

//    else
//        return false;

//}