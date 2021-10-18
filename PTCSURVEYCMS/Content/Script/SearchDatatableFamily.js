﻿


$(document).ready(function () {
    debugger;
    /*  document.getElementById('secondtable').style.display = 'block';*/
    document.getElementById('tapshil').style.display = 'block';
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

    $("#test").focusout(function () {
     //   debugger;
        var PRONOBYNAME = $('#test').val();
        $.ajax({
            type: "post",
            url: "/PTC/PropertyNoList?pname=" + PRONOBYNAME + "",
            data: { PRONOBYNAME: PRONOBYNAME },
            datatype: "json",
            traditional: true,
            success: function (data) {
                district = '<option value="-1">Select Property No.</option>';
                district = '<option value="">Select All.</option>';
                for (var i = 0; i < data.length; i++) {
                    district = district + '<option value=' + data[i].Value + '>' + data[i].Text + '</option>';
                }
                $('#PRONOBYNAME').html(district);
            }

        });
    });

    $("#poname").focusout(function () {
        debugger;
        var Name = $('#poname').val();
        $.ajax({
            type: "post",
            url: "/PTC/OwnerNameList?pname=" + Name + "",
            data: { Name: Name },
            datatype: "json",
            traditional: true,
            success: function (data) {
                district = '<option value="-1">Select Name</option>';
                district = '<option value="">Select All.</option>';
                for (var i = 0; i < data.length; i++) {
                    district = district + '<option value=' + data[i].Value + '>' + data[i].Text + '</option>';
                }
                $('#Name').html(district);
            }

        });
    });

    $("#test").keyup(function () {
      //  debugger;
        var PRONOBYNAME = $('#test').val();
        $.ajax({
            type: "post",
            url: "/PTC/OwnerNameListFocus?pname=" + PRONOBYNAME + "",
            data: "{'prefixText':'" + document.getElementById('test').value + "'}",
            datatype: "json",
            traditional: true,
            success: function (data) {            
                district = '<option value=""></option>';
                for (var i = 0; i < data.length; i++) {
                    district = district + '<option value="' + data[i].Value + '"></option>';
                }
              
             $('#tests').html(district);
            }

        });
    });

});



function None() {
    ActiveEmployee();
    document.getElementById('common').style.display = 'none';
    document.getElementById('const').style.display = 'none';
    document.getElementById('consstate').style.display = 'none';
    document.getElementById('ConsPerNo').style.display = 'none';
    document.getElementById('adfilbtn').style.display = 'none';
    document.getElementById('byname').style.display = 'none';
    document.getElementById('byprono').style.display = 'none';
    document.getElementById('filterbyname').style.display = 'none';
    document.getElementById('filterbyProperty').style.display = 'none';
    document.getElementById('filter').style.display = 'none';
   
}

function show1() {
    ActiveEmployee();
    var element = document.getElementById("cusmargin");
    element.classList.remove("MyClass");
    document.getElementById('common').style.display = 'block';
    document.getElementById('const').style.display = 'block';
    document.getElementById('consstate').style.display = 'none';
    document.getElementById('ConsPerNo').style.display = 'none';
    document.getElementById('adfilbtn').style.display = 'block';
    document.getElementById('byname').style.display = 'none';
    document.getElementById('byprono').style.display = 'none';
    document.getElementById('tapshil').style.display = 'none';
    document.getElementById('filterbyname').style.display = 'none';
    document.getElementById('filter').style.display = 'block';
    document.getElementById('filterbyProperty').style.display = 'none';
      document.getElementById('secondtable').style.display = 'none';
    document.getElementById('firsttable').style.display = 'block';
   

}

function show2() {
    ActiveEmployee();

    var element = document.getElementById("cusmargin");
    element.classList.remove("MyClass");
    document.getElementById('common').style.display = 'block';
    document.getElementById('consstate').style.display = 'block';
    document.getElementById('const').style.display = 'none';
    document.getElementById('ConsPerNo').style.display = 'none';
    document.getElementById('adfilbtn').style.display = 'block';
    document.getElementById('byname').style.display = 'none';
    document.getElementById('byprono').style.display = 'none';
    document.getElementById('tapshil').style.display = 'none';
    document.getElementById('filterbyname').style.display = 'none';
    document.getElementById('filterbyProperty').style.display = 'none';
    document.getElementById('filter').style.display = 'block';
    document.getElementById('secondtable').style.display = 'none';
    document.getElementById('firsttable').style.display = 'block';


}

function show3() {
    ActiveEmployee();
    document.getElementById('common').style.display = 'block';
    document.getElementById('ConsPerNo').style.display = 'block';
    document.getElementById('const').style.display = 'block';
    document.getElementById('consstate').style.display = 'block';
    document.getElementById('adfilbtn').style.display = 'block';

}
function show4() {
    ActiveEmployee();
    var element = document.getElementById("cusmargin");
    element.classList.add("MyClass");
    document.getElementById('byprono').style.display = 'block';
    document.getElementById('common').style.display = 'none';
    document.getElementById('ConsPerNo').style.display = 'none';
    document.getElementById('const').style.display = 'none';
    document.getElementById('consstate').style.display = 'none';
    document.getElementById('adfilbtn').style.display = 'block';
    document.getElementById('byname').style.display = 'none';
    document.getElementById('filterbyname').style.display = 'block';
    document.getElementById('filterbyProperty').style.display = 'none';
    document.getElementById('filter').style.display = 'none';



}
function show5() {
    ActiveEmployee();
    var element = document.getElementById("cusmargin");
    element.classList.add("MyClass");
    document.getElementById('byname').style.display = 'block';
    document.getElementById('common').style.display = 'none';
    document.getElementById('ConsPerNo').style.display = 'none';
    document.getElementById('const').style.display = 'none';
    document.getElementById('consstate').style.display = 'none';
    document.getElementById('adfilbtn').style.display = 'block';
    document.getElementById('byprono').style.display = 'none';
    document.getElementById('filterbyname').style.display = 'none';
    document.getElementById('filterbyProperty').style.display = 'block';
    document.getElementById('filter').style.display = 'none';

}

function show6() {
    var element = document.getElementById("cusmargin");
    element.classList.remove("MyClass");
    document.getElementById('common').style.display = 'block';
    document.getElementById('ConsPerNo').style.display = 'block';
    document.getElementById('adfilbtn').style.display = 'block';
    document.getElementById('const').style.display = 'none';
    document.getElementById('consstate').style.display = 'none';
    document.getElementById('byprono').style.display = 'none';
    document.getElementById('byname').style.display = 'none';
    document.getElementById('tapshil').style.display = 'none';
    document.getElementById('filterbyname').style.display = 'none';
    document.getElementById('filterbyProperty').style.display = 'none';
    document.getElementById('filter').style.display = 'block';
    document.getElementById('secondtable').style.display = 'none';
    document.getElementById('firsttable').style.display = 'block';
    
}

function show7() {
    document.getElementById('tapshil').style.display = 'block';
    document.getElementById('common').style.display = 'none';
    document.getElementById('ConsPerNo').style.display = 'none';
    document.getElementById('adfilbtn').style.display = 'none';
    document.getElementById('const').style.display = 'none';
    document.getElementById('consstate').style.display = 'none';
    document.getElementById('byprono').style.display = 'none';
    document.getElementById('byname').style.display = 'none';
    document.getElementById('filterbyname').style.display = 'none';
    document.getElementById('filterbyProperty').style.display = 'none';
    document.getElementById('filter').style.display = 'block';
    document.getElementById('secondtable').style.display = 'none';
    document.getElementById('firsttable').style.display = 'block';

}

function SearchByName() {
    debugger;
    PROOWNAME = $('#Name').val();
    poname = $('#poname').val();
    window.location.href = "/Search/SurveyListSearch?q=" + poname + "&n=" + PROOWNAME + "";
    document.getElementById('secondtable').style.display = 'block';
    document.getElementById('firsttable').style.display = 'none';
  
}

function SearchByProperty() {
    debugger;
    poname = $('#PRONOBYNAME').val();
    PROOWNAME   = $('#test').val();
    window.location.href = "/Search/SurveyListSearch?q=" + poname + "&n=" + PROOWNAME + "";
    document.getElementById('secondtable').style.display = 'block';
    document.getElementById('firsttable').style.display = 'none';

}
function Search() {
    debugger;
    Filter = "f";
    PrabhagList = $('#PrabhagList').val();
    WardList = $('#WardList').val();
    CSDate = $('#CSDate').val();
    CEDate = $('#CEDate').val();
    OCNO = $('#OCNO').val();
    PRONOBYNAME = $('#PRONOBYNAME').val();
    PROOWNAME = $('#test').val();
    poname = $('#poname').val();
    Name = $('#Name').val();
    CPNO = $('#CPNO').val();
    OCNOY = $('#OCNOY').val();
    var value = Filter + "," + PrabhagList + "," + WardList + "," + CEDate + "," + CSDate + "," + OCNO + "," + PRONOBYNAME + "," + PROOWNAME + "," + poname + "," + Name + "," + CPNO + "," + OCNOY;;

    // alert(value );
    oTable = $('#datatableActive').DataTable();
    oTable.search(value).draw();
    oTable.search("");

    //    document.getElementById('USER_ID_FK').value = -1;
}
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

    $('#datatableActive').DataTable({
        //  "processing": true, // for show progress bar  
        "serverSide": true, // for process server side  
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once  
        "pageLength": 5,
        "searching": true,
        destroy: true,
        // "order": [
        //       [0, "asc"]
        //],
        "ajax": {
            "url": "/PTC/LoadData/",
            "type": "POST",
            "datatype": "json",

        },

        //"columnDefs":
        //    [{
        //        "targets": [0],
        //        "visible": false,
        //        "searchable": false
        //    }],
        "columns": [
            { "data": "PrabhagNo" },
            { "data": "WardName_No" },
            { "data": "ConstStartYear" },
            { "data": "CompletionYear" },
            {
                "data": "PropOwnerFirstName", "render": function (data, type, full, meta) {

                    if (full["PropOwnerFirstName"] != null && full["PropOwnerLastName"] != null) {

                        return '<p> ' + uppercaseWords(full["PropOwnerFirstName"])
                            + ' ' + uppercaseWords(full["PropOwnerLastName"]) + '</p>';

                    }

                    if (full["PropOwnerFirstName"] != null && full["PropOwnerLastName"] == null) {

                        return '<p> ' + uppercaseWords(full["PropOwnerFirstName"])
                            + ' ' + uppercaseWords(full["PropOwnerMiddleName"]) + '</p>';

                    }
                    else {
                        //
                        return 'Not Available';
                    }
                }
            },

            { "data": "PropOwnerTelephoneNo" },
            { "data": "NewPropertyNo" },
            { "data": "PropertyNo" },
            { "data": "OldHouseNo1" },


            { "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" title="View"  style="cursor:pointer"   onclick="View(' + full["PropertyId"] + ')"  >View&nbsp; / <a  href="javascript:void(0)" title="Download" style="cursor:pointer"   onclick="Download(' + full["PropertyId"] + ')"  > Download'; }, "width": "10%" },
            { "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)"title="Download"  style="cursor:pointer"   onclick="DownloadQRCode(' + full["PropertyId"] + ')"  >Download'; }, "width": "10%" },
            //   {
            //"render": function (data, type, full, meta) {
            //    return '<a  href="javascript:void(0)"  style="cursor:pointer"   onclick="Bill(' + full["PropertyId"] + ')"  >Bill &nbsp; /  <a href="javascript:void(0)"  style="cursor:pointer"  onclick = "SendRemainder(' + full["PropertyId"] + ')" > Bill Reminder</i>'
            //}, "width": "10%"
            // },
            { "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" style="cursor:pointer" title="Edit"  onclick="Edit(' + full["PropertyId"] + ')"  ><i class="material-icons edit-icon" style="font-size=18px!important">edit</i>&nbsp;<i class="material-icons" style="color: #0e91f0;font-size: 150%;">/</i>&nbsp; <a  href="javascript:void(0)"  title="Delete"  style="cursor:pointer" saveForm()  onclick="Delete(' + full["PropertyId"] + ')"  ><i class="material-icons delete-icon">delete</i>'; }, "width": "10%" }
            /*   { "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" class="tooltip1" style="cursor:pointer"   onclick="View(' + full["PropertyId"] + ')"  >View&nbsp; / <a  href="javascript:void(0)" class="tooltip1" style="cursor:pointer"   onclick="Download(' + full["PropertyId"] + ')"  > Download'; }, "width": "10%" }*/
        ]
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
