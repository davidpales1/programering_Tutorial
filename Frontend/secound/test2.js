let cars = [{
    brand: "Volvo",
    model: "262 GL"
},
{
    brand: "Saab",
    model: "900 Turbo"
},
{
    brand: "Volvo",
    model: "244 GLT"
},
{
    brand: "BMW",
    model: "2002 ti"
}
];

// function loadMyCars(){
//     let result="";
//     for(let i=0;i < cars.length; i++){
//         result += "<li>" + cars[i].brand + "  " + cars[i].model + "</li>";
//     }
//     //result += "<h3>Totally " + i + " cars</h3>";
//     result += "<h3>Totally " + cars.length + " cars</h3>";

//     document.getElementById("myCars").innerHTML = result;
// }

function loadMyCars(){
    for(let i=0;i < cars.length; i++){
        let node = document.createElement("li");
        let textnode = document.createTextNode(cars[i].brand + "  " + cars[i].model);
        node.appendChild(textnode);
        document.getElementById("myCars").appendChild(node);
    }

    let node = document.createElement("h3");
    let textnode = document.createTextNode("Totally " + cars.length + " cars");
    node.appendChild(textnode);
    document.getElementById("myCars").appendChild(node);
}