//Task 1: hide the "Open Positions" heading
//Capture the h3 headings
var TgHeadings = document.getElementsByTagName("h3")
for (var Heading of TgHeadings) {
    //find the heading that says Open Positions
    if (Heading.textContent == "Open Positions") {
        //Hide the heading
        Heading.style.visibility = "hidden";
    }
}

//Task 2: Change the icon for fully paid insurance
//Capture the checkbox icon
var ChkBox = document.getElementsByClassName("x-icon-check circle")[0];
//Alter the icon
ChkBox.style = "margin: 0px auto; color: rgb(0, 0, 0); background-color: rgb(255, 255, 255)";

//task 3:Change "Catered Lunch to Upper Case"
 //Capture h4 elements
 TgHeadings = document.getElementsByTagName("h4")
 //loop through headings to find the one that says catered lunch
 for (Heading of TgHeadings) {
    if (Heading.textContent == "Catered Lunch") {
        //change it to uppercase
        Heading.textContent = Heading.textContent.toUpperCase();
        break;
    }
 }

 //Task 4: Add onclick event tot "Perks + Benefits" to show alert
//capture the div that contains the h3 tag "Perks + Benefits"
var TgDiv = document.getElementsByClassName("el143 x-text x-text-headline")[0];
//Add onclick event to show alert
TgDiv.onclick = function() {alert('i love infotrust');};

//Bonus Task 5: Duplicate list items that are important to you
//Capture the lists of perks and beneefits
var TgUls = document.getElementsByClassName("x-feature-list");
//create empty array of perks
var TgPerks = []
for (var Ul of TgUls) {
//determine if list item is a favortie perk or benefit
    for (var Li of Ul.children) {
        if(Li.innerText.includes("Fully Paid Insurance") == true  || 
        Li.innerText.includes("Open PTO") == true || 
        Li.innerText.includes("Paid Time Off to Volunteer") == true  ||
        Li.innerText.includes("Competitive Salary") == true) {
            //add list item to array
            TgPerks.push(Li.cloneNode(true));
        }
    }
}
//Grab the second UL to add my favorite perks to the list
var TgUl = document.getElementsByClassName("x-feature-list")[1];

//add my favorite perks to the list
for (var Perk of TgPerks) {
    TgUl.appendChild(Perk);
}


{
    "name":"Jonathan Wilson", 
    "email":"jon.wilsond@gmail.com", 
    “favoriteSports”:
    ["Kansas State Wildcats", 
    "Las Vegas Golden Knights", 
    "Cincinnati Reds", 
    "FC Cincinnati"],
    "Education":
    [“Currently completing the Max Technical Training C#/.NET Bootcamp",
    "Bachelor of Economics”],
     "professionalExperience":[
          { "Company":"Morgan Stanley", "Position":”Margin Risk Reporting and Automation Programmer”},
          { "Company":"Morgan Stanley", "Position":”Wealth Management Risk Analyst”},
          { "Company":"Flagship Financial", "Position":”Loan Officer Assistant”}]
}
    