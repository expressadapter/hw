

var capacity;
var entrances;
var exits;
var minArrVehicle;
var maxArrVehicle;
var maxArrTime;
var minServiceTime; 
var maxServiceTime;
var minLeaVehicle ;
var maxLeaVehicle ;
var minLeaTime ;
var maxLeaTime ;
var timeCounter=1;
var avgWtimeEnt = 0;
var avgWtimeEx = 0;
var maxWaiting = 0;
var avgTimeSpent=0;

var timeA = 0;
var timeB = 0;
var timeC = 0;

var a;
var x;
var y;
var z;

var carIdentification = 1;
var entranceIdentification = 1;
var exitIdentification = 1;


var leavingVehicleArray = new Array();
var goneVehicles = new Array();
goneVehicles.push([0,0,0]);

var entrancesArray=new Array();
var exitsArray=new Array();
var parkArea=new Array();


function prepareEnviroment() {
    capacity = document.getElementById("capacity");
    entrances = document.getElementById("entrances");
    exits = document.getElementById("exits");
    minArrVehicle = document.getElementById("minArrVehicle");
    maxArrVehicle = document.getElementById("maxArrVehicle");
    minArrTime = document.getElementById("minArrTime");
    maxArrTime = document.getElementById("maxArrTime");
    minServiceTime = document.getElementById("minServiceTime");
    maxServiceTime = document.getElementById("maxServiceTime");
    minLeaTime = document.getElementById("minLeaTime");
    maxLeaTime = document.getElementById("maxLeaTime");
    runFor = document.getElementById("runFor");

    a = parseInt(runFor.value);
    x = parseInt(entrances.value);
    y = parseInt(capacity.value);
    z = parseInt(exits.value);
   
    
    prepareExitsEntrancesParkArea();

    prepareSimulationScreen();
 

    
}
function start() {
    
    document.getElementById("prepareButton").addEventListener("click", prepareEnviroment, false);
    document.getElementById("startButton").addEventListener("click", startSimulation, false);
}

function startSimulation() {
   
    while (a > 0) {
        leavingServingTimeCheckAndExit();

        serviceTimeCheck();
        arrivingServingTimeCheckandPlacePark();

        var arrivingVehicleNumber = getRandomInt(parseInt(minArrVehicle.value), parseInt(maxArrVehicle.value));
        var arrivingVehicleArray = new Array(arrivingVehicleNumber);
        var arrivingTime;

        for (i = 0; i < arrivingVehicleNumber; i++) {
            arrivingVehicleArray[i] = new Array();
            arrivingVehicleArray[i].push(carIdentification);
            arrivingTime = getRandomInt(parseInt(minArrTime.value), parseInt(maxArrTime.value));
            avgWtimeEnt += arrivingTime;
            if (arrivingTime > maxWaiting) {
                maxWaiting =arrivingTime;
            }
            arrivingVehicleArray[i].push(arrivingTime);
            carIdentification++;
        }

        carPlacementEntrances(arrivingVehicleNumber, arrivingVehicleArray);


        avgTimeSpentGoneCars();

        alert(timeCounter + " seconds pass\n" + "Average Entrance Time Spend:" +Math.ceil(avgWtimeEnt / carIdentification) + "\nAverage Exit Time Spend:" +Math.ceil(avgWtimeEx / carIdentification) + "\nMaximum Waiting Time:" + maxWaiting + "\nAverage Time Spent:" +avgTimeSpent/carIdentification);
        a--;
        timeCounter++;
    }
}
function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}
function prepareExitsEntrancesParkArea() {

    for (i = 0; i < x; i++) {
        entrancesArray[i] = new Array();
        entrancesArray[i].push(entranceIdentification);
        entranceIdentification++;
    }
    for (i = 0; i < y; i++) {
        parkArea[i] == 'undefined';
    }

    for (i = 0; i < z; i++) {
        exitsArray[i] = new Array();
        exitsArray[i].push(exitIdentification);
        exitIdentification++;
    }
}
function carPlacementEntrances(arrivingCarNumber, arrivingArray) {
    for (i = 0; i < arrivingCarNumber; i++) {
        entrancesArray = entrancesArray.sort(function (a, b) { return a.length - b.length; });
        entrancesArray[0].push(arrivingArray[0]);
        var para = document.createElement("p");
        para.setAttribute("class", "car");
        para.setAttribute("id", "car" + arrivingArray[0][0]);
        para.innerHTML = arrivingArray[0][0];
        var element = document.getElementById("entrance"+entrancesArray[0][0]);
        element.appendChild(para);
        arrivingArray.shift();
    }
}

    

function arrivingServingTimeCheckandPlacePark() {
    var serviceTime;
    var leavingTime
        for (i = 0; i < x; i++) {
            var childCounter = 1;
            if (typeof entrancesArray[i][1] != "undefined" && entrancesArray[i][1] != null && entrancesArray[i][1].length > 0) {
                   
                if (entrancesArray[i][1][1] == 0) {
        
                    for (k = 0; k < y; k++) {
                        if (parkArea[k] == "undefined" || parkArea[k] == "NaN" || parkArea[k] == null) {
                        
                            parkArea[k] = entrancesArray[i][1];
                           
                            entrancesArray[i][1].push(getRandomInt(parseInt(minServiceTime.value), parseInt(maxServiceTime.value)));
                            var time;
                            time=getRandomInt(parseInt(minLeaTime.value), parseInt(maxLeaTime.value))
                            entrancesArray[i][1].push(time);
                            avgWtimeEx += time;
                            if (time > maxWaiting) {
                                maxWaiting = time;
                            }

                            var element2 = document.getElementById("entrance" + entrancesArray[i][0]);
                           element2.removeChild(element2.childNodes[childCounter]);

                           var para = document.createElement("p");
                            para.setAttribute("class", "car");
                            para.setAttribute("id", "car" + entrancesArray[i][1][0]);
                            para.innerHTML = entrancesArray[i][1][0];
                            var element = document.getElementById("parkArea" + (k + 1));
                            element.appendChild(para);

                            

                            childCounter++;
                            entrancesArray[i].splice(1, 1);
                            break;
                        } 
                    }

                } else {
                    
                    entrancesArray[i][1][1]--;


                } 
            } }
}

function serviceTimeCheck() {
    for (i = 0; i < y; i++) {
        if (typeof parkArea[i] != "undefined" && parkArea[i] != null && parkArea[i].length > 0)
            if (parkArea[i][2] == 0) {

                exitsArray = exitsArray.sort(function (a, b) { return a.length - b.length; });
                exitsArray[0].push(parkArea[i]);

                var para = document.createElement("p");
                para.setAttribute("class", "car");
                para.setAttribute("id", "carExit" + parkArea[i][0]);
                para.innerHTML = parkArea[i][0];
                var element = document.getElementById("exit" + exitsArray[0][0]);
                element.appendChild(para);

                var element = document.getElementById("car" + parkArea[i][0]);
                element.setAttribute("style", "display:none");

                delete parkArea[i];

            } else {
                parkArea[i][2]--;
            }

    }
   

}
function leavingServingTimeCheckAndExit() {
   
    for (i = 0; i < z; i++) {
       
        if (typeof exitsArray[i][1] != "undefined" && exitsArray[i][1] != null && exitsArray[i][1].length > 0) {
            if (exitsArray[i][1][3] == 0) {
                goneVehicles.push(exitsArray[i][1]);

                var element = document.getElementById("carExit" + exitsArray[i][1][0]);
                element.setAttribute("style", "display:none");

                exitsArray[i].splice(1,1);
             
            }

            else {
               
                exitsArray[i][1][3]--;

            }
        }
    }

}
function prepareSimulationScreen() {
       for (i = 0; i <capacity.value;i++){
      var para = document.createElement("div");
         para.setAttribute("class", "parkAreaFree");
      para.setAttribute("id","parkArea"+(i + 1));
    para.innerHTML = i + 1;
    var element = document.getElementById("parkArea");
    element.appendChild(para);
    }
    for (i = 0; i < entrances.value; i++) {
        var para = document.createElement("div");
        para.setAttribute("class", "entrances");
        para.setAttribute("id", "entrance"+(i + 1));
        para.innerHTML = i + 1;
        var element = document.getElementById("entranceSection");
        element.appendChild(para);

    }
    for (i = 0; i < exits.value; i++) {
        var para = document.createElement("div");
        para.setAttribute("class", "exits");
        para.setAttribute("id","exit"+( i + 1));
        para.innerHTML=i+1;
        var element = document.getElementById("exitSection");
        element.appendChild(para);

    }

}
function avgTimeSpentGoneCars() {
    
    for (i = 0; i < goneVehicles.length; i++) {
        timeA += goneVehicles[i][1];
        timeB += goneVehicles[i][2];
        timeC += goneVehicles[i][3];
    }
    avgTimeSpent =timeA+timeB+timeC;
}



window.addEventListener("load", start, false);