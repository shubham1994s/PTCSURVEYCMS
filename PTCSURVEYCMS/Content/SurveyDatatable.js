

$(document).ready(function () {

    ActiveEmployee();
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
                    //return '<p> ' + full["PropOwnerFirstName"].charAt(0).toUpperCase() + full["PropOwnerFirstName"].substr(1).toLowerCase()
                    //    + ' ' + full["PropOwnerLastName"].charAt(0).toUpperCase() + full["PropOwnerLastName"].substr(1).toLowerCase() + '</p>' } },

                    if (full["PropOwnerFirstName"] != null && full["PropOwnerLastName"] != null) {
                        return '<p> ' + full["PropOwnerFirstName"].charAt(0).toUpperCase() + full["PropOwnerFirstName"].substr(1).toLowerCase()
                            + ' ' + full["PropOwnerLastName"].charAt(0).toUpperCase() + full["PropOwnerLastName"].substr(1).toLowerCase() + '</p>';

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
               
 
            { "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" class="tooltip1" style="cursor:pointer"   onclick="View(' + full["PropertyId"] + ')"  >View&nbsp; / <a  href="javascript:void(0)" class="tooltip1" style="cursor:pointer"   onclick="Download(' + full["PropertyId"] + ')"  > Download'; }, "width": "10%" },
            { "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" class="tooltip1" style="cursor:pointer"   onclick="DownloadQRCode(' + full["PropertyId"] + ')"  >Download'; }, "width": "10%" },
            { "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" style="cursor:pointer" title="Edit" class="title-tip" onclick="Edit(' + full["PropertyId"] + ')"  ><i class="material-icons edit-icon" style="font-size=18px!important">edit</i>&nbsp;<i class="material-icons" style="color: #0e91f0;font-size: 150%;">/</i>&nbsp; <a  href="javascript:void(0)"  title="Delete" class="title-tip" style="cursor:pointer" saveForm()  onclick="Delete(' + full["PropertyId"] + ')"  ><i class="material-icons delete-icon">delete</i>'; }, "width": "10%" }
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