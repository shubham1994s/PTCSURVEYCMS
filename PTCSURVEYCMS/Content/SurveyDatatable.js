

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
                        return 'Not Available';
                    }
                } },

            { "data": "PropOwnerTelephoneNo" },
                { "data": "NewPropertyNo" },
                { "data": "PropertyNo" },
            { "data": "OldHouseNo1" },
               
                { "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" class="tooltip1" style="cursor:pointer"   onclick="Edit(' + full["PropertyId"] + ')"  ><i class="material-icons edit-icon">edit</i>'; }, "width": "10%" },
        { "render": function (data, type, full, meta) { return '<a  href="javascript:void(0)" class="tooltip1" style="cursor:pointer"   onclick="View(' + full["PropertyId"] + ')"  >View&nbsp; / <a  href="javascript:void(0)" class="tooltip1" style="cursor:pointer"   onclick="Download(' + full["PropertyId"] + ')"  > Download'; }, "width": "10%" }
    
        ]
    });

}



