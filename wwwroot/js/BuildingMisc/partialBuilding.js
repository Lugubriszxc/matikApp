//call for the functions by default
//initialize the variables here as global
var selectedBuildingId;
var selectedBuilding;
var buildingList = {};

populateBuildingTable();

//to populate the building table
function populateBuildingTable()
{
    $('#buildingData').DataTable().destroy();
    if(!$.fn.DataTable.isDataTable('#buildingData'))
    {
        $('#buildingData').DataTable({
            responsive: true,
            ajax:
            {
                url: '../api/adminapi/getBuildings',
                dataSrc: ''
            },
            columns:
            [
                {data: 'buildingId'},
                {data: 'buildingName'},
                {
                    data: 'buildingId',
                    render : function (data, type, row)
                    {
                        return btnBuilding(data);
                    }
                },
            ]
        });
    }
    //get the buildings list 
    getBuilding();
}

//to render buttons in action index
function btnBuilding(buildingId)
{
    return "<center><a class='btn btn-success buildingUpdate' data-buildingId=" + buildingId + "><i class='fa-solid fa-pen-to-square' style='color : #ffffff;'></i></a> | <a class='btn btn-danger buildingDelete' data-buildingId=" + buildingId + "><i class='fa-solid fa-trash' style='color : #ffffff;'></i></a></center>"
}

//get the data of the building and store it to array
function getBuilding()
{
    $.ajax("../api/adminapi/getBuildings")
    .done(function(result){
        buildingList = result;
    });
}

//this is to create a building and save it to the database
$("#createBuilding").click((e) => {
    var arrData = {};

    //count the number of element inside the form
    var formelements = $("#createBuildingForm .form-group");

    //getting the data from the form
    var formInputs = $("#createBuildingForm").serializeArray();
    formInputs.forEach(function(item){
        arrData[item.name] = item.value;
    });

    //console.log(arrData);

    let emptyEl = new Boolean(false);
    //alternative of bool
    if(formInputs[0].value === '')
    {
        //if the department name is empty then return true
        emptyEl = Boolean(true);
    }
    else{
        //if the department name is not empty then return false
        emptyEl = Boolean(false);
    }

    //if all elements are not empty
    if(formInputs.length === formelements.length && emptyEl ===  Boolean(false))
    {

        //Call API to add Building
        $.ajax({
            url: "../api/adminapi/createBuilding",
            type: "POST",
            data:
            {
                bld : arrData,
            },
        })
        .done(function(){
            $("#createBuildingForm")[0].reset();
            $("#modalBuildingCreate").modal("toggle");
            alertSuccess();
            populateBuildingTable();
        });
    }
    else   
    {
        alertError("Input the necessary elements!");
    }
});

//when clicking the delete button
$("tbody").delegate(".buildingDelete", "click", function(e){
    var i = e.target.closest("a").getAttribute("data-buildingId");
    if(i != null)
    {
        //Insert code here for delete
        selectedBuildingId = i;
        alertDeleteConfirmation(selectedBuildingId);
    }
});

//after confirming delete, call this function
function deleteBuilding(selectedBuildingId)
{
    //AJAX delete building
    $.ajax({
        url: "../api/adminapi/deleteBuilding",
        type: "POST",
        data:
        {
            buildingId : selectedBuildingId,
        },
    }).done(function(){
        alertSuccess();
        populateBuildingTable();
    })
}

//when clicking the update button
$("tbody").delegate(".buildingUpdate", "click", function(e){
    var i = e.target.closest("a").getAttribute("data-buildingId");
    if(i != null)
    {
        $("#updateBuildingForm")[0].reset();
        $("#modalBuildingUpdate").modal("toggle");

        selectedBuildingId = i;
        selectedBuilding = buildingList.find(element => element.buildingId == i);

        oFormObject = document.forms["updateBuildingForm"];
        initForm(oFormObject, selectedBuilding);
    }
});

//to populate the selected element to the form
function initForm(form, data){
    Object.getOwnPropertyNames(data).forEach(function(item){
    var currentElem = form.elements[item.charAt(0).toUpperCase() + item.slice(1)];
    //console.log(currentElem);

    if( currentElem == null ){return;}

    if(currentElem.tagName == "SELECT"){
        var selectChildren = Array.from(currentElem.children);
        var matchedOpt = selectChildren.find(opt => opt.value == selectedBuilding.buildingId);
    if(matchedOpt){
        matchedOpt.selected = true;
    }
    }else{
        form.elements[item.charAt(0).toUpperCase() + item.slice(1)].setAttribute("value",data[item]); 
    }
    });
}

//after clicking update
$("#updateBuilding").click(function(){
    alertSaveChanges();
});

function proceedUpdate()
{
    var arrData = {};

    //count the number of element inside the form
    var formelements = $("#updateBuildingForm .form-group");

    //getting the data from the form
    var formInputs = $("#updateBuildingForm").serializeArray();
    formInputs.forEach(function(item){
        arrData[item.name] = item.value;
    });

    arrData.buildingId = selectedBuildingId;

    let emptyEl = new Boolean(false);
    //alternative of bool
    if(formInputs[0].value === '')
    {
        //if the department name is empty then return true
        emptyEl = Boolean(true);
    }
    else{
        //if the department name is not empty then return false
        emptyEl = Boolean(false);
    }

    //if all elements are not empty
    if(formInputs.length === formelements.length && emptyEl ===  Boolean(false))
    {

        //Call API to add Building
        $.ajax({
            url: "../api/adminapi/updateBuilding",
            type: "POST",
            data:
            {
                bld : arrData,
            },
        })
        .done(function(){
            $("#updateBuildingForm")[0].reset();
            $("#modalBuildingUpdate").modal("toggle");
            alertSuccess();
            populateBuildingTable();
        });
    }
    else   
    {
        alertError("Input the necessary elements!");
    }
}

//sweet alert
//display delete confirmation
function alertDeleteConfirmation(selectedBuildingId)
{
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes!'
    }).then((result) => {
        if(result.isConfirmed){
            deleteBuilding(selectedBuildingId);
        }
    })
}

//display update confirmation
function alertSaveChanges()
{
    Swal.fire({
        title: 'Do you want to save the changes?',
        showCancelButton: true,
        confirmButtonText: 'Save',
    }).then((result) => {
        if(result.isConfirmed){
            proceedUpdate();
        }
    })
}