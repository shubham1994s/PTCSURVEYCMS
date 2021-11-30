


$(document).ready(function () {
    // debugger;
    /* document.getElementById('secondtable').style.display = 'block';*/

    document.getElementById('filterbyProperty').style.display = 'none';
    show1();
    FillPrabhagListNo();
    FillWardListNo();
    FillCEDate();
    FillCSDate();
    $("#SearchText").val("");
    $("#para").show().delay(3000).show().fadeOut('slow');

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
        debugger;
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
                    district = district + '<option value="' + data[i].Value + '">' + data[i].Text.replace(new RegExp("(?:\\b|_)([a-z])", 'g'), function ($2) { return $2.toUpperCase(); }); + '</option>';
                }
                $('#Name').html(district);
            }

        });
    });

    $("#test").keyup(function () {
        debugger;
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

    $("#poname").change(function () {


        var PropertyNo = $("#poname").val();
        $.ajax({
            url: "/PTC/IsPropertyNoExists?PropertyNo=" + PropertyNo,
            type: "POST",
            data: { PropertyNo: PropertyNo }
        })
            .done(function (msg) {
                if (msg == 1) {
                    $('#err_PropertyNo').html("<span style='color:#002bff;'>This Property No. Is Available</span>");
                } else {
                    $('#err_PropertyNo').text('This Property Number Is Not Exist!');
                }
            });
    });


    function check() {
        document.getElementById("consd").checked = true;
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
        /*  document.getElementById('secondtable').style.display = 'none';*/
        document.getElementById('firsttable').style.display = 'block';
    }
    function uncheck() {
        document.getElementById("red").checked = false;
    }

    window.onload = check();

});

function FillPrabhagListNo() {
    var PrabhagListNo = $('#PrabhagList').val();
    $.ajax({
        type: "post",
        url: "/PTC/PrabhagList",
        data: { userId: PrabhagListNo },
        datatype: "json",
        traditional: true,
        success: function (data) {
            district = '<option value="-1" >Select Prabhag No.</option>';
            district = '<option value="All" >Select All.</option>';
            for (var i = 0; i < data.length; i++) {
                district = district + '<option value=' + data[i].Value + '>' + data[i].Text + '</option>';
            }
            //district = district + '</select>';
            $('#PrabhagList').html(district);
        }
    });

}


function FillHTNo() {
    var HTList = $('#HT').val();
    $.ajax({
        type: "post",
        url: "/PTC/HTList",
        data: { userId: HTList },
        datatype: "json",
        traditional: true,
        success: function (data) {
            district = '<option value="-1" >Select Heritage Tree</option>';
            district = '<option value="All" >Select All.</option>';
            for (var i = 0; i < data.length; i++) {
                district = district + '<option value=' + data[i].Value + '>' + data[i].Text + '</option>';
            }
            //district = district + '</select>';
            $('#HT').html(district);
        }
    });

}

function FillWardListNo() {
    var WardListNo = $('#WardList').val();
    $.ajax({
        type: "post",
        url: "/PTC/WardList",
        data: { userId: WardListNo },
        datatype: "json",
        traditional: true,
        success: function (data) {
            // district = '<option value="-1">Select Ward No.</option>';
            district = '<option value="All">Select All.</option>';
            for (var i = 0; i < data.length; i++) {
                district = district + '<option value=' + data[i].Value + '>' + data[i].Text + '</option>';
            }
            //district = district + '</select>';
            $('#WardList').html(district);
        }
    });

}

function FillCSDate() {
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
}

function FillCEDate() {
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
}

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
    //debugger;
    FillPrabhagListNo();
    FillWardListNo();
    FillCSDate();
    FillCEDate();
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
    document.getElementById('filterbyProperty').style.display = 'none';
    document.getElementById('filterbyno').style.display = 'none';
    document.getElementById('filterbystatus').style.display = 'none';
    document.getElementById('filter').style.display = 'block';
    document.getElementById('firsttable').style.display = 'block';
    document.getElementById('Thirdtable').style.display = 'none';
    document.getElementById('Fourthtable').style.display = 'none';
    document.getElementById('RWHT').style.display = 'none';
    document.getElementById('CPT').style.display = 'none';
    document.getElementById('SEPT').style.display = 'none';
    document.getElementById('HTT').style.display = 'none';
    document.getElementById('WCT').style.display = 'none';
    document.getElementById('NVAT').style.display = 'none';
    document.getElementById('DLT').style.display = 'none';
    document.getElementById('STKT').style.display = 'none';
    document.getElementById('SGSKT').style.display = 'none';
    document.getElementById('BUET').style.display = 'none';

    $("#OCNOY").empty();
    $("#OCNOY").append("<option value='ALL' selected>Select All.</option><option value = 'Y' > YES</option > <option value='N'>NO</option><option value='NA'>Not Selected</option>");
    $("#CPNO").empty();
    $("#CPNO").append("<option value='ALL'>Select All.</option>< option value = 'Y' > YES</option ><option value='N'>NO</option><option value='NA'>Not Selected</option>");
    $("#OCNO").empty();
    $("#OCNO").append("<option value='' selected>मालमत्तेची सद्यस्तिथी</option>< option value = 'ALL' > Select All.</option >  <option value='Safe'>भिंती (सुस्थितीत)</option><option value='Danger'>भिंती (धोकदायक)</option> <option value='Safe2'>छप्पर (सुस्थितीत)</option> <option value='Danger2'>छप्पर (धोकदायक)</option><option value='Safe3'>काँलम (सुस्थितीत)</option><option value='Danger3'>काँलम (धोकदायक)</option>");

    document.getElementById('CPNO').value = ''
    document.getElementById('OCNOY').value = ''
    ActiveEmployee();
}

function show2() {
    debugger;
    FillPrabhagListNo();
    FillWardListNo();
    FillCSDate();
    FillCEDate();
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
    document.getElementById('filter').style.display = 'none';
    document.getElementById('filterbystatus').style.display = 'block';
    document.getElementById('filterbyno').style.display = 'none';
    document.getElementById('firsttable').style.display = 'none';
    document.getElementById('Thirdtable').style.display = 'none';
    document.getElementById('Fourthtable').style.display = 'block';
    document.getElementById('RWHT').style.display = 'none';
    document.getElementById('CPT').style.display = 'none';
    document.getElementById('SEPT').style.display = 'none';
    document.getElementById('HTT').style.display = 'none';
    document.getElementById('WCT').style.display = 'none';
    document.getElementById('NVAT').style.display = 'none';
    document.getElementById('DLT').style.display = 'none';
    document.getElementById('STKT').style.display = 'none';
    document.getElementById('SGSKT').style.display = 'none';
    document.getElementById('BUET').style.display = 'none';
    $("#OCNO").empty();
    $("#OCNO").append("<option value='' selected>मालमत्तेची सद्यस्तिथी</option>< option value = 'ALL' > Select All.</option >  <option value='Safe'>भिंती (सुस्थितीत)</option><option value='Danger'>भिंती (धोकदायक)</option> <option value='Safe2'>छप्पर (सुस्थितीत)</option> <option value='Danger2'>छप्पर (धोकदायक)</option><option value='Safe3'>काँलम (सुस्थितीत)</option><option value='Danger3'>काँलम (धोकदायक)</option>");

    $("#OCNOY").empty();
    $("#OCNOY").append("<option value='ALL' selected>Select All.</option><option value = 'Y' >YES</option > <option value='N'>NO</option><option value='NA'>Not Selected</option>");
    $("#CPNO").empty();
    $("#CPNO").append("<option value='ALL'>Select All.</option><option value = 'Y' > YES</option><option value='N'>NO</option><option value='NA'>Not Selected</option>");

    document.getElementById('CPNO').value = ''
    document.getElementById('OCNOY').value = ''
    document.getElementById('CSDate').value = ''
    document.getElementById('CEDate').value = ''
    PropertyActive();
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
    document.getElementById('filterbyname').style.display = 'none';
    document.getElementById('filterbyProperty').style.display = 'block';
    document.getElementById('filter').style.display = 'none';



}
function show5() {
    debugger;
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
    document.getElementById('filterbyname').style.display = 'block';
    document.getElementById('filterbyProperty').style.display = 'none';
    document.getElementById('filter').style.display = 'none';

}

function show6() {
    debugger;
    FillPrabhagListNo();
    FillWardListNo();
    FillCSDate();
    FillCEDate();
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
    document.getElementById('filter').style.display = 'none';
    document.getElementById('filterbystatus').style.display = 'none';
    document.getElementById('filterbyno').style.display = 'block';
    document.getElementById('firsttable').style.display = 'none';
    document.getElementById('Thirdtable').style.display = 'block';
    document.getElementById('Fourthtable').style.display = 'none';
    document.getElementById('RWHT').style.display = 'none';
    document.getElementById('CPT').style.display = 'none';
    document.getElementById('SEPT').style.display = 'none';
    document.getElementById('HTT').style.display = 'none';
    document.getElementById('WCT').style.display = 'none';
    document.getElementById('NVAT').style.display = 'none';
    document.getElementById('DLT').style.display = 'none';
    document.getElementById('STKT').style.display = 'none';
    document.getElementById('SGSKT').style.display = 'none';
    document.getElementById('BUET').style.display = 'none';
    //  ActiveEmployee();
    $("#OCNO").empty();
    $("#OCNO").append("<option value='' selected>मालमत्तेची सद्यस्तिथी</option>< option value = 'ALL' > Select All.</option >  <option value='Safe'>भिंती (सुस्थितीत)</option><option value='Danger'>भिंती (धोकदायक)</option> <option value='Safe2'>छप्पर (सुस्थितीत)</option> <option value='Danger2'>छप्पर (धोकदायक)</option><option value='Safe3'>काँलम (सुस्थितीत)</option><option value='Danger3'>काँलम (धोकदायक)</option>");

    $("#OCNOY").empty();
    $("#OCNOY").append("<option value='ALL' selected>Select All.</option><option value = 'Y' >YES</option > <option value='N'>NO</option><option value='NA'>Not Selected</option>");
    $("#CPNO").empty();
    $("#CPNO").append("<option value='ALL'>Select All.</option><option value = 'Y' > YES</option><option value='N'>NO</option><option value='NA'>Not Selected</option>");

    document.getElementById('CSDate').value = ''
    document.getElementById('CEDate').value = ''
    StatusActive();
}

function show7() {
    FillPrabhagListNo();
    FillWardListNo();
    FillCSDate();
    FillCEDate();
    // debugger;
    document.getElementById("bpn").checked = true;
    var element = document.getElementById("cusmargin");
    element.classList.add("MyClass");
    document.getElementById('tapshil').style.display = 'block';
    document.getElementById('common').style.display = 'none';
    document.getElementById('ConsPerNo').style.display = 'none';
    document.getElementById('adfilbtn').style.display = 'block';
    document.getElementById('const').style.display = 'none';
    document.getElementById('consstate').style.display = 'none';
    document.getElementById('byprono').style.display = 'block';
    document.getElementById('byname').style.display = 'none';
    document.getElementById('filterbyname').style.display = 'none';
    document.getElementById('filterbyno').style.display = 'none';
    document.getElementById('filterbystatus').style.display = 'none';
    document.getElementById('filterbyProperty').style.display = 'block';
    document.getElementById('filter').style.display = 'none';
    document.getElementById('filterbystatus').style.display = 'none';
    document.getElementById('filterbyno').style.display = 'none';
    document.getElementById('firsttable').style.display = 'block';
    document.getElementById('Thirdtable').style.display = 'none';
    document.getElementById('Fourthtable').style.display = 'none';
    document.getElementById('filterbystatus').style.display = 'none';
    document.getElementById('filterbyno').style.display = 'none';
    $("#OCNO").empty();
    $("#OCNO").append("<option value='' selected>मालमत्तेची सद्यस्तिथी</option>< option value = 'ALL' > Select All.</option >  <option value='Safe'>भिंती (सुस्थितीत)</option><option value='Danger'>भिंती (धोकदायक)</option> <option value='Safe2'>छप्पर (सुस्थितीत)</option> <option value='Danger2'>छप्पर (धोकदायक)</option><option value='Safe3'>काँलम (सुस्थितीत)</option><option value='Danger3'>काँलम (धोकदायक)</option>");

    $("#OCNOY").empty();
    $("#OCNOY").append("<option value='ALL' selected>Select All.</option><option value = 'Y' >YES</option > <option value='N'>NO</option><option value='NA'>Not Selected</option>");
    $("#CPNO").empty();
    $("#CPNO").append("<option value='ALL'>Select All.</option><option value = 'Y' > YES</option><option value='N'>NO</option><option value='NA'>Not Selected</option>");
    ActiveEmployee();

}


function show8() {
    debugger;
    FillPrabhagListNo();
    FillWardListNo();
    FillCSDate();
    FillCEDate();
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
    document.getElementById('filter').style.display = 'none';
    document.getElementById('filterbystatus').style.display = 'block';
    document.getElementById('filterbyno').style.display = 'none';
    document.getElementById('firsttable').style.display = 'none';
    document.getElementById('Thirdtable').style.display = 'none';
    document.getElementById('Fourthtable').style.display = 'block';
    document.getElementById('CPT').style.display = 'none';
    document.getElementById('SEPT').style.display = 'none';
    document.getElementById('consstate').style.display = 'none';
    document.getElementById('HTT').style.display = 'none';
    document.getElementById('WCT').style.display = 'none';
    document.getElementById('NVAT').style.display = 'none';
    document.getElementById('DLT').style.display = 'none';
    document.getElementById('STKT').style.display = 'none';
    document.getElementById('SGSKT').style.display = 'none';
    document.getElementById('BUET').style.display = 'none';
    document.getElementById('RWHT').style.display = 'block';

    
    $("#RWH").empty();
    $("#RWH").append("<option value='ALL' selected>Select All.</option><option value = 'Y' >YES</option > <option value='N'>NO</option>");
   
    document.getElementById('CPNO').value = ''
    document.getElementById('OCNOY').value = ''
    document.getElementById('CSDate').value = ''
    document.getElementById('CEDate').value = ''
    PropertyActive();
}


function show9() {
    debugger;
    FillPrabhagListNo();
    FillWardListNo();
    FillCSDate();
    FillCEDate();
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
    document.getElementById('filter').style.display = 'none';
    document.getElementById('filterbystatus').style.display = 'block';
    document.getElementById('filterbyno').style.display = 'none';
    document.getElementById('firsttable').style.display = 'none';
    document.getElementById('Thirdtable').style.display = 'none';
    document.getElementById('Fourthtable').style.display = 'block';
    document.getElementById('RWHT').style.display = 'none';
    document.getElementById('SEPT').style.display = 'none';
    document.getElementById('consstate').style.display = 'none';
    document.getElementById('HTT').style.display = 'none';
    document.getElementById('WCT').style.display = 'none';
    document.getElementById('NVAT').style.display = 'none';
    document.getElementById('DLT').style.display = 'none';
    document.getElementById('STKT').style.display = 'none';
    document.getElementById('SGSKT').style.display = 'none';
    document.getElementById('BUET').style.display = 'none';
    document.getElementById('CPT').style.display = 'block';
    $("#CP").empty();
    $("#CP").append("<option value='ALL' selected>Select All.</option><option value = 'Y' >YES</option > <option value='N'>NO</option>");

    document.getElementById('CPNO').value = ''
    document.getElementById('OCNOY').value = ''
    document.getElementById('CSDate').value = ''
    document.getElementById('CEDate').value = ''
    PropertyActive();
}

function show10() {
    debugger;
    FillPrabhagListNo();
    FillWardListNo();
    FillCSDate();
    FillCEDate();
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
    document.getElementById('filter').style.display = 'none';
    document.getElementById('filterbystatus').style.display = 'block';
    document.getElementById('filterbyno').style.display = 'none';
    document.getElementById('firsttable').style.display = 'none';
    document.getElementById('Thirdtable').style.display = 'none';
    document.getElementById('Fourthtable').style.display = 'block';
    document.getElementById('RWHT').style.display = 'none';
    document.getElementById('CPT').style.display = 'none';
    document.getElementById('consstate').style.display = 'none';
    document.getElementById('HTT').style.display = 'none';
    document.getElementById('WCT').style.display = 'none';
    document.getElementById('NVAT').style.display = 'none';
    document.getElementById('DLT').style.display = 'none';
    document.getElementById('STKT').style.display = 'none';
    document.getElementById('SGSKT').style.display = 'none';
    document.getElementById('BUET').style.display = 'none';
    document.getElementById('SEPT').style.display = 'block';
    $("#SEP").empty();
    $("#SEP").append("<option value='ALL' selected>Select All.</option><option value = 'Y' >YES</option > <option value='N'>NO</option>");

    document.getElementById('CPNO').value = ''
    document.getElementById('OCNOY').value = ''
    document.getElementById('CSDate').value = ''
    document.getElementById('CEDate').value = ''
    PropertyActive();
}

function show11() {
    debugger;
    FillPrabhagListNo();
    FillWardListNo();
    FillCSDate();
    FillCEDate();
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
    document.getElementById('filter').style.display = 'none';
    document.getElementById('filterbystatus').style.display = 'block';
    document.getElementById('filterbyno').style.display = 'none';
    document.getElementById('firsttable').style.display = 'none';
    document.getElementById('Thirdtable').style.display = 'none';
    document.getElementById('Fourthtable').style.display = 'block';
    document.getElementById('RWHT').style.display = 'none';
    document.getElementById('CPT').style.display = 'none';
    document.getElementById('consstate').style.display = 'none';
    document.getElementById('WCT').style.display = 'none';
    document.getElementById('NVAT').style.display = 'none';
    document.getElementById('SEPT').style.display = 'none';
    document.getElementById('DLT').style.display = 'none';
    document.getElementById('STKT').style.display = 'none';
    document.getElementById('SGSKT').style.display = 'none';
    document.getElementById('BUET').style.display = 'none';
    document.getElementById('HTT').style.display = 'block';
   
    document.getElementById('CPNO').value = ''
    document.getElementById('OCNOY').value = ''
    document.getElementById('CSDate').value = ''
    document.getElementById('CEDate').value = ''
    PropertyActive();
    FillHTNo();
}


function show12() {
    debugger;
    FillPrabhagListNo();
    FillWardListNo();
    FillCSDate();
    FillCEDate();
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
    document.getElementById('filter').style.display = 'none';
    document.getElementById('filterbystatus').style.display = 'block';
    document.getElementById('filterbyno').style.display = 'none';
    document.getElementById('firsttable').style.display = 'none';
    document.getElementById('Thirdtable').style.display = 'none';
    document.getElementById('Fourthtable').style.display = 'block';
    document.getElementById('RWHT').style.display = 'none';
    document.getElementById('CPT').style.display = 'none';
    document.getElementById('consstate').style.display = 'none';
    document.getElementById('SEPT').style.display = 'none';
    document.getElementById('HTT').style.display = 'none';
    document.getElementById('DLT').style.display = 'none';
    document.getElementById('STKT').style.display = 'none';
    document.getElementById('SGSKT').style.display = 'none';
    document.getElementById('BUET').style.display = 'none';
    document.getElementById('WCT').style.display = 'block';
    document.getElementById('NVAT').style.display = 'block';
    $("#WC").empty();
    $("#WC").append("<option value='ALL' selected>Select All.</option><option value = 'Y' >YES</option > <option value='N'>NO</option>");
    $("#NVA").empty();
    $("#NVA").append("<option value='ALL' selected>Select All.</option><option value = 'R' >Residential</option > <option value='S'>Sp.Category</option><option value='I'>Industrial</option>");

    document.getElementById('CPNO').value = ''
    document.getElementById('OCNOY').value = ''
    document.getElementById('CSDate').value = ''
    document.getElementById('CEDate').value = ''
    PropertyActive();
}

function show13() {
    debugger;
    FillPrabhagListNo();
    FillWardListNo();
    FillCSDate();
    FillCEDate();
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
    document.getElementById('filter').style.display = 'none';
    document.getElementById('filterbystatus').style.display = 'block';
    document.getElementById('filterbyno').style.display = 'none';
    document.getElementById('firsttable').style.display = 'none';
    document.getElementById('Thirdtable').style.display = 'none';
    document.getElementById('Fourthtable').style.display = 'block';
    document.getElementById('RWHT').style.display = 'none';
    document.getElementById('CPT').style.display = 'none';
    document.getElementById('consstate').style.display = 'none';
    document.getElementById('SEPT').style.display = 'none';
    document.getElementById('HTT').style.display = 'none';
    document.getElementById('WCT').style.display = 'none';
    document.getElementById('NVAT').style.display = 'none';
    document.getElementById('STKT').style.display = 'none';
    document.getElementById('SGSKT').style.display = 'none';
    document.getElementById('BUET').style.display = 'none';
    document.getElementById('DLT').style.display = 'block';
    $("#DL").empty();
    $("#DL").append("<option value='ALL' selected>Select All.</option><option value = 'HC' >घर बंद</option > <option value='PCL'>कायम घर बंद</option><option value='OM'>बाहेरून मोजमाप</option>");

    document.getElementById('CPNO').value = ''
    document.getElementById('OCNOY').value = ''
    document.getElementById('CSDate').value = ''
    document.getElementById('CEDate').value = ''
    PropertyActive();
}


function show14() {
    debugger;
    FillPrabhagListNo();
    FillWardListNo();
    FillCSDate();
    FillCEDate();
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
    document.getElementById('filter').style.display = 'none';
    document.getElementById('filterbystatus').style.display = 'block';
    document.getElementById('filterbyno').style.display = 'none';
    document.getElementById('firsttable').style.display = 'none';
    document.getElementById('Thirdtable').style.display = 'none';
    document.getElementById('Fourthtable').style.display = 'block';
    document.getElementById('RWHT').style.display = 'none';
    document.getElementById('CPT').style.display = 'none';
    document.getElementById('consstate').style.display = 'none';
    document.getElementById('SEPT').style.display = 'none';
    document.getElementById('HTT').style.display = 'none';
    document.getElementById('WCT').style.display = 'none';
    document.getElementById('NVAT').style.display = 'none';
    document.getElementById('DLT').style.display = 'none';
    document.getElementById('SGSKT').style.display = 'none';
    document.getElementById('BUET').style.display = 'none';
    document.getElementById('STKT').style.display = 'block'; 
    $("#STK").empty();
    $("#STK").append("<option value='ALL' selected>Select All.</option><option value = 'FST' >फक्त सेप्टिक टैंक</option > <option value='STS'>सेप्टिक टैंक + शोषखड्डा</option><option value='Other'>इतर</option>");
    document.getElementById('CPNO').value = ''
    document.getElementById('OCNOY').value = ''
    document.getElementById('CSDate').value = ''
    document.getElementById('CEDate').value = ''
    PropertyActive();
}

function show15() {
    debugger;
    FillPrabhagListNo();
    FillWardListNo();
    FillCSDate();
    FillCEDate();
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
    document.getElementById('filter').style.display = 'none';
    document.getElementById('filterbystatus').style.display = 'block';
    document.getElementById('filterbyno').style.display = 'none';
    document.getElementById('firsttable').style.display = 'none';
    document.getElementById('Thirdtable').style.display = 'none';
    document.getElementById('Fourthtable').style.display = 'block';
    document.getElementById('RWHT').style.display = 'none';
    document.getElementById('CPT').style.display = 'none';
    document.getElementById('consstate').style.display = 'none';
    document.getElementById('SEPT').style.display = 'none';
    document.getElementById('HTT').style.display = 'none';
    document.getElementById('WCT').style.display = 'none';
    document.getElementById('NVAT').style.display = 'none';
    document.getElementById('DLT').style.display = 'none';
    document.getElementById('STKT').style.display = 'none';
    document.getElementById('SGSKT').style.display = 'block';
    document.getElementById('BUET').style.display = 'block';
    $("#SGSK").empty();
    $("#SGSK").append("<option value='ALL' selected>Select All.</option><option value = 'Y' >होय</option > <option value='N'>नाही</option>");
    $("#BUE").empty();
    $("#BUE").append("<option value='ALL' selected>Select All.</option><option value = 'BG' >भूमिगत गटार</option > <option value='UG'>उघडी गटार </option><option value='O'>इतर</option>");
    document.getElementById('CPNO').value = ''
    document.getElementById('OCNOY').value = ''
    document.getElementById('CSDate').value = ''
    document.getElementById('CEDate').value = ''
    PropertyActive();
}

function SearchByName() {
    debugger;
    poname = $('#PRONOBYNAME').val();
    PROOWNAME = $('#test').val();
    window.location.href = "/Search/SurveyListSearch?x=" + poname + "&y=" + PROOWNAME + "";
    document.getElementById('secondtable').style.display = 'block';
    document.getElementById('firsttable').style.display = 'none';

}

function SearchByProperty() {
    debugger;
    poname = $('#poname').val();
    PROOWNAME = $('#Name').val();
    window.location.href = "/Search/SurveyListSearch?q=" + poname + "&n=" + PROOWNAME + "";
    document.getElementById('secondtable').style.display = 'block';
    document.getElementById('firsttable').style.display = 'none';

}
function Search() {
    // debugger;
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
}



function SearchByNo() {
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

    oTable = $('#ThirddatatableActive').DataTable();


    oTable.search(value).draw();
    oTable.search("");
}



function SearchByStatus() {
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
    RWH = $('#RWH').val();
    CP = $('#CP').val();
    SEP = $('#SEP').val();
    HT = $('#HT').val();
    WC = $('#WC').val();
    NVA = $('#NVA').val();
    DL = $('#DL').val();
    STK = $('#STK').val(); 
    SGSK = $('#SGSK').val();
    BUE = $('#BUE').val();
    
    
    
    var value = Filter + "," + PrabhagList + "," + WardList + "," + CEDate + "," + CSDate + "," + OCNO + "," + PRONOBYNAME + "," + PROOWNAME + "," + poname + "," + Name + "," + CPNO + "," + OCNOY + "," + RWH + "," + CP + "," + SEP + "," + HT + "," + DL + "," + NVA + "," + STK + "," + SGSK + "," + BUE ;

    // alert(value );

    oTable = $('#FourthdatatableActive').DataTable();

    oTable.search(value).draw();
    oTable.search("");
}


function send() {
    debugger

    $('#para').css('display', 'block')

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
        "lengthMenu": [[5, 10, 25, 50], [5, 10, 25, 50]],
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

                        return '<p> ' + (full["PropOwnerFirstName"]).replace(new RegExp("(?:\\b|_)([a-z])", 'g'), function ($1) { return $1.toUpperCase(); })
                            + ' ' + (full["PropOwnerLastName"]).replace(new RegExp("(?:\\b|_)([a-z])", 'g'), function ($2) { return $2.toUpperCase(); }); + '</p>';

                    }

                    if (full["PropOwnerFirstName"] != null && full["PropOwnerLastName"] == null && full["PropOwnerMiddleName"] != null) {

                        return '<p> ' + (full["PropOwnerFirstName"]).replace(new RegExp("(?:\\b|_)([a-z])", 'g'), function ($1) { return $1.toUpperCase(); })
                            + ' ' + (full["PropOwnerMiddleName"]).replace(new RegExp("(?:\\b|_)([a-z])", 'g'), function ($1) { return $1.toUpperCase(); }); + '</p>';

                    }

                    if (full["PropOwnerFirstName"] != null) {

                        return '<p> ' + (full["PropOwnerFirstName"]).replace(new RegExp("(?:\\b|_)([a-z])", 'g'), function ($1) { return $1.toUpperCase(); })

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


function StatusActive() {

    $('#ThirddatatableActive').DataTable({

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
        "lengthMenu": [[5, 10, 25, 50], [5, 10, 25, 50]],
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
            {
                "data": "YConstPermNo", "render": function (data, type, full, meta) {

                    if (full["YConstPermNo"] == 0 && full["NConstPermNo"] == 0) {

                        return 'Not Available';

                    }
                    if (full["YConstPermNo"] == 1 && full["NConstPermNo"] == 0) {

                        return 'Yes';

                    }
                    if (full["YConstPermNo"] == 0 && full["NConstPermNo"] == 1) {

                        return 'No';

                    }
                }
            },
            { "data": "ConstPermNo" },
            {
                "data": "YPermUseNo", "render": function (data, type, full, meta) {

                    if (full["YPermUseNo"] == 0 && full["NPermUseNo"] == 0) {

                        return 'Not Available';

                    }
                    if (full["YPermUseNo"] == 1 && full["NPermUseNo"] == 0) {

                        return 'Yes';

                    }
                    if (full["YPermUseNo"] == 0 && full["NPermUseNo"] == 1) {

                        return 'No';

                    }
                }
            },
            { "data": "PermUseNo" },
            {
                "data": "PropOwnerFirstName", "render": function (data, type, full, meta) {

                    if (full["PropOwnerFirstName"] != null && full["PropOwnerLastName"] != null) {

                        return '<p> ' + (full["PropOwnerFirstName"]).replace(new RegExp("(?:\\b|_)([a-z])", 'g'), function ($1) { return $1.toUpperCase(); })
                            + ' ' + (full["PropOwnerLastName"]).replace(new RegExp("(?:\\b|_)([a-z])", 'g'), function ($2) { return $2.toUpperCase(); }); + '</p>';

                    }

                    if (full["PropOwnerFirstName"] != null && full["PropOwnerLastName"] == null && full["PropOwnerMiddleName"] != null) {

                        return '<p> ' + (full["PropOwnerFirstName"]).replace(new RegExp("(?:\\b|_)([a-z])", 'g'), function ($1) { return $1.toUpperCase(); })
                            + ' ' + (full["PropOwnerMiddleName"]).replace(new RegExp("(?:\\b|_)([a-z])", 'g'), function ($1) { return $1.toUpperCase(); }); + '</p>';

                    }

                    if (full["PropOwnerFirstName"] != null) {

                        return '<p> ' + (full["PropOwnerFirstName"]).replace(new RegExp("(?:\\b|_)([a-z])", 'g'), function ($1) { return $1.toUpperCase(); })

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

function PropertyActive() {

    $('#FourthdatatableActive').DataTable({

        //  "processing": true, // for show progress bar  
        "serverSide": true, // for process server side  
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once  
        "pageLength": 5,
        "searching": true,
        destroy: true,

        "ajax": {
            "url": "/PTC/LoadData/",
            "type": "POST",
            "datatype": "json",

        },
        "lengthMenu": [[5, 10, 25, 50], [5, 10, 25, 50]],
        "columns": [

            { "data": "PrabhagNo" },
            { "data": "WardName_No" },


            {
                "data": "PropOwnerFirstName", "render": function (data, type, full, meta) {

                    if (full["PropOwnerFirstName"] != null && full["PropOwnerLastName"] != null) {

                        return '<p> ' + (full["PropOwnerFirstName"]).replace(new RegExp("(?:\\b|_)([a-z])", 'g'), function ($1) { return $1.toUpperCase(); })
                            + ' ' + (full["PropOwnerLastName"]).replace(new RegExp("(?:\\b|_)([a-z])", 'g'), function ($2) { return $2.toUpperCase(); }); + '</p>';

                    }

                    if (full["PropOwnerFirstName"] != null && full["PropOwnerLastName"] == null && full["PropOwnerMiddleName"] != null) {

                        return '<p> ' + (full["PropOwnerFirstName"]).replace(new RegExp("(?:\\b|_)([a-z])", 'g'), function ($1) { return $1.toUpperCase(); })
                            + ' ' + (full["PropOwnerMiddleName"]).replace(new RegExp("(?:\\b|_)([a-z])", 'g'), function ($1) { return $1.toUpperCase(); }); + '</p>';

                    }

                    if (full["PropOwnerFirstName"] != null) {

                        return '<p> ' + (full["PropOwnerFirstName"]).replace(new RegExp("(?:\\b|_)([a-z])", 'g'), function ($1) { return $1.toUpperCase(); })

                    }
                    else {
                        //
                        return 'Not Available';
                    }
                }
            },

            {
                "data": "Safe", "render": function (data, type, full, meta) {

                    if (full["Safe"] == 0 && full["Danger"] == 0) {

                        return 'Not Available';

                    }
                    if (full["Safe"] == 1 && full["Danger"] == 0) {

                        return 'सुस्थितीत';

                    }
                    if (full["Safe"] == 0 && full["Danger"] == 1) {

                        return 'धोकदायक';

                    }
                }
            },

            {
                "data": "Safe2", "render": function (data, type, full, meta) {

                    if (full["Safe2"] == 0 && full["Danger2"] == 0) {

                        return 'Not Available';

                    }
                    if (full["Safe2"] == 1 && full["Danger2"] == 0) {

                        return 'सुस्थितीत';

                    }
                    if (full["Safe2"] == 0 && full["Danger2"] == 1) {

                        return 'धोकदायक';

                    }
                }
            },

            {
                "data": "Safe3", "render": function (data, type, full, meta) {

                    if (full["Safe3"] == 0 && full["Danger3"] == 0) {

                        return 'Not Available';

                    }
                    if (full["Safe3"] == 1 && full["Danger3"] == 0) {

                        return 'सुस्थितीत';

                    }
                    if (full["Safe3"] == 0 && full["Danger3"] == 1) {

                        return 'धोकदायक';

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




