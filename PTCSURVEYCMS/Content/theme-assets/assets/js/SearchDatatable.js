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

function ActiveEmployee() {
  

    $('#searchtable').DataTable({
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
            "url": "/PTC/LoadData/",
            "type": "POST",
            "datatype": "json",

        },

      
        "columns": [
            { "data": "PrabhagNo" },
            { "data": "WardName_No" },
            { "data": "ConstStartYear" },
            { "data": "ConstStartYear" },
            { "data": "PropertyId" },
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