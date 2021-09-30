

$(document).ready(function () {
    debugger;


    $("#para").show().delay(3000).show().fadeOut('slow');
    ActiveEmployee();
    
    $("#SearchText").change(function () {
        debugger;

        var SearchText = $("#SearchText").val();
        // var selectoption = $("#selectoption").value();
        var selectoption = $('input[type=radio][name=selectoption]:checked').attr('id');
        $.ajax({
            url: "/PTC/SelectionNotExists?SearchText=" + SearchText + "&selectoption=" + selectoption +"",
            type: "POST",
            data: { SearchText: SearchText }
        })
            .done(function (msg) {
              
                $('#err_PropertyNo').text(msg);
              
            });
    });

 
});
function SendRemainder(q) {
    debugger;
 

    $.ajax({
        url: "/PTC/SurveyList?q=" + q + "&selectoption=PropertyNumber&Reminder=Reminder",
        type: "POST",
       
        dataType: 'json',
        contentType: false,
        processData: false,
        success: function (response) {
            debugger;
            if (response.success) {
            
               
                $('#demoModalSuccess').modal('show');
            } else {
                
                $('#demoModalError').modal('show');
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
                $('#demoModalSuccess').modal('show');
            } else {
                $('#demoModalError').modal('show');
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
        "pageLength": 10,
        "order": [
               [0, "desc"]
        ],
        destroy: true,
        "ajax": {
            "url": "/PTC/getPropertyDetails/",
            "tye": "GET",
            "datatype": "json",
        },

        "columnDefs":
        [{
            "targets": [0],
            "visible": false,
            "searchable": false
            }],
        "columns": [
            { "data": "PropertyId" },
            {
                "data": "PropOwnerFirstName", "render": function (data, type, full, meta) {
                
                    if (full["PropOwnerFirstName"] != null && full["PropOwnerLastName"] != null) {
                      
                        return '<p> ' + uppercaseWords(full["PropOwnerFirstName"]) 
                            + ' ' + uppercaseWords(full["PropOwnerLastName"]) + '</p>';

                    }
                    else {
//
                        return 'Not Available';
                    }
                } },

            { "data": "PropOwnerTelephoneNo" },
                { "data": "NewPropertyNo" },
                { "data": "PropertyNo" },
            { "data": "OldHouseNo1" },
               
 
            { "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" title="View"  style="cursor:pointer"   onclick="View(' + full["PropertyId"] + ')"  >View&nbsp; / <a  href="javascript:void(0)" title="Download" style="cursor:pointer"   onclick="Download(' + full["PropertyId"] + ')"  > Download'; }, "width": "10%" },
            { "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)"title="Download"  style="cursor:pointer"   onclick="DownloadQRCode(' + full["PropertyId"] + ')"  >Download'; }, "width": "10%" },
            {
                "render": function (data, type, full, meta) {
                    return '<a  href="javascript:void(0)"  style="cursor:pointer"   onclick="Bill(' + full["PropertyId"] + ')"  >Bill &nbsp; /  <a href="javascript:void(0)"  style="cursor:pointer"  onclick = "SendRemainder(' + full["PropertyId"] + ')" > Bill Reminder</i>' }, "width": "10%" },
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