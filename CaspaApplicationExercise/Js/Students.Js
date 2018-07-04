"option strict"

function loaded() {
    $.getJSON("http://localhost:50162/Students/List")
        .done(function (resp) {
            console.log(resp);
            display(resp.Data);
            listIt = resp;
        });
}

function display(students) {
    var tbody = $("tbody");
    tbody.html("");
    for (var student of students) {
        var tr = $("<tr></tr>");
        tr.append($("<td>" + student.Id + "</td>"));
        tr.append($("<td>" + student.Name + "</td>"));
        tr.append($("<td>" + student.UserName + "</td>"));
        tr.append($("<td>" + student.Password + "</td>"));
        tr.append($("<td>" + student.Address + "</td>"));
        tr.append($("<td>" + student.City + "</td>"));
        tr.append($("<td>" + student.State + "</td>"));
        // tr.append($("<td><button class='btn btn-danger' onclick='completed(" + task + ")'>Completed</button></td>"));
        tbody.append(tr);
    }
}

function LoadForm() {
    var form = $("#LoadForm");
    form.innerHTML = "";
    var elem = document.getElementById('addStudent');
    elem.parentNode.removeChild(elem);
    var htmlStr =['<form>', 
        '<div class="form-group">',
            '<label for="fName">First and Last Name</label>',
            '<input type="email" class="form-control" id="fName" placeholder="Enter your name" name="Email">',
        '</div>',
        '<div class="form-group">',
            '<label for="fUserName">Username</label>',
            '<input type="Username" class="form-control" id="fUserName" placeholder="Username" name="UserName">',
        '</div>',
        '<div class="form-group">',
            '<label for="fPassword">Password</label>',
            '<input type="password" class="form-control" id="fPassword" placeholder="Password" name="Password">',
        '</div>',
        '<div class="form-group">',
            '<label for="fAddress">Address</label>',
            '<input type="Address" class="form-control" id="fAddress" placeholder="Address" name="Address">',
        '</div>',
        '<div class="form-group">',
            '<label for="fCity">City</label>',
            '<input type="City" class="form-control" id="fCity" placeholder="City" name="City">',
        '</div>',
        '<div class="form-group">',
            '<label for="fStateCode">StateCode</label>',
            '<input type="StateCode" class="form-control" id="fState" placeholder="##" name="State">',
        '</div>',
    '</form>'].join("");
    form.append(htmlStr);
    htmlStr = '<button id="CancelStudent" onclick="ClearForm();" class="btn btn-secondary">Cancel</button>';
    form.append(htmlStr);
    htmlStr = '<button id="addStudent" onclick="AddStudent();" class="btn btn-primary">Add Student</button>';
    form.append(htmlStr);
    
}

function ClearForm() {
    var form = document.getElementById("LoadForm")
    while( form.hasChildNodes() ){
        form.removeChild(form.lastChild);
    } 
    form.innerHTML = '<button id="addStudent" onclick="LoadForm();" class="btn btn-primary">Add Student</button>'
}

function AddStudent(){
    var form = document.getElementById("LoadForm")
    var student = {
        Name: document.getElementById("fName").value,
        UserName: document.getElementById("fUserName").value,
        Password: document.getElementById("fPassword").value,
        Address: document.getElementById("fAddress").value,
        City: document.getElementById("fCity").value,
        State: document.getElementById("fState").value,
        Active: true,
    };
    console.log(student)
    $.post("http://localhost:#####/Users/Change", student)
            .done(function(resp) {
                console.log(resp);
                display();
                clearForm();
        });
}