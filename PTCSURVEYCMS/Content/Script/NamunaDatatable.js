

$(document).ready(function () {
    //debugger;
    var PrabhagListNo = $('#PrabhagList').val();
    $.ajax({
        type: "post",
        url: "/PTC/PrabhagList",
        data: { userId: PrabhagListNo },
        datatype: "json",
        traditional: true,
        success: function (data) {
            district = '<option value="-1">Select Prabhag No.</option>';
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
            for (var i = 0; i < data.length; i++) {
                district = district + '<option value=' + data[i].Value + '>' + data[i].Text + '</option>';
            }
            //district = district + '</select>';
            $('#CSDate').html(district);
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
    /*$('#para').css('display','block')*/
    //$("#para").show().delay(3000).show().fadeOut('slow').css("background-color", "yellow");
    var x = document.getElementById("snackbar");
    x.className = "show";
    setTimeout(function () { x.className = x.className.replace("show", ""); }, 4000);
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

    window.location.href = "/PTC/NamunaForm?q=" + ID;
}


function View(ID) {
    window.location.href = "/PTC/ViewNamunaForm?q=" + ID;
}
var url;
function Download(ID) {
    debugger;

    url = "/PTC/ViewNamunaForm?q=" + ID;

    var myWindow;
    myWindow = window.open(url, "myWindow", "_blank", 'fullscreen=yes');
    myWindow.print();
    var blob = new Blob([myWindow], { type: "application/octetstream" });
    // myWindow.close();
    //  link = url.createObjectURL(blob);
    //   myWindow.remove(url);
}




function closeWin() {
    myWindow.close();
}



function ActiveEmployee() {

    $('#datatableActive').DataTable({
        //  "processing": true, // for show progress bar  
        "serverSide": true, // for process server side  
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once  
        "pageLength": 5,
        "searching": true,
        // "order": [
        //       [0, "asc"]
        //],
        "ajax": {
            "url": "/PTC/LoadDataNamuna",
            "type": "POST",
            "datatype": "json",

        },
        "lengthMenu": [[5, 10, 25, 50], [5, 10, 25, 50]],
        "columnDefs":
            [{
                "targets": [0],
                "visible": false,
                "searchable": false
            }],
        "columns": [
            { "data": "NamunaId" },
            {
                "data": "OwnerName", "render": function (data, type, full, meta) {




                    if (full["OwnerName"] != null) {

                        return '<p> ' + (full["OwnerName"])

                    }
                    else {

                        return 'Not Available';
                    }
                }
            },

            {
                "data": "OccupantName", "render": function (data, type, full, meta) {




                    if (full["OccupantName"] != null) {

                        return '<p> ' + (full["OccupantName"])

                    }
                    else {

                        return 'Not Available';
                    }
                }
            },

            {
                "data": "AppilcantName", "render": function (data, type, full, meta) {




                    if (full["AppilcantName"] != null) {

                        return '<p> ' + (full["AppilcantName"])

                    }
                    else {

                        return 'Not Available';
                    }
                }
            },
            {
                "data": "PropertyNo", "render": function (data, type, full, meta) {




                    if (full["PropertyNo"] != null) {

                        return '<p> ' + (full["PropertyNo"])

                    }
                    else {

                        return 'Not Available';
                    }
                }
            },
            { "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" title="View"  style="cursor:pointer"   onclick="View(' + full["NamunaId"] + ')"  >View&nbsp; / <a  href="javascript:void(0)" title="Download" style="cursor:pointer"   onclick="Download(' + full["NamunaId"] + ')"  > Download'; }, "width": "10%" },
            
       
            { "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" style="cursor:pointer" title="Edit"  onclick="Edit(' + full["NamunaId"] + ')"  ><i class="material-icons edit-icon" style="font-size=18px!important">edit</i>&nbsp;<i class="material-icons" style="color: #0e91f0;font-size: 150%;">/</i>&nbsp; <a  href="javascript:void(0)"  title="Delete"  style="cursor:pointer" saveForm()  onclick="Delete(' + full["NamunaId"] + ')"  ><i class="material-icons delete-icon">delete</i>'; }, "width": "10%" }
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
        window.location.href = "/PTC/DeleteNamuna?q=" + ID;
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