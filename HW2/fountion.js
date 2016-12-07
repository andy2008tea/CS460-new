var num=0,result=0,numshow="0"; 
var operate=0; 
var calcul=0;
var quit=0; 
function command(num){ 
var str=String(document.calculator.numScreen.value); 
str=(str!="0") ? ((operate==0) ? str : "") : "";
str=str + String(num); 
document.calculator.numScreen.value=str; 
operate=0;
quit=0;
} 
function dzero(){ 
var str=String(document.calculator.numScreen.value); 
str=(str!="0") ? ((operate==0) ? str + "00" : "0") : "0"; 
document.calculator.numScreen.value=str; 
operate=0; 
} 
function dot(){ 
var str=String(document.calculator.numScreen.value); 
str=(str!="0") ? ((operate==0) ? str : "0") : "0"; 
for(i=0; i<=str.length;i++){ 
if(str.substr(i,1)==".") return false; 
} 
str=str + "."; 
document.calculator.numScreen.value=str; 
operate=0; 
} 
function del(){ 
var str=String(document.calculator.numScreen.value); 
str=(str!="0") ? str : ""; 
str=str.substr(0,str.length-1); 
str=(str!="") ? str : "0"; 
document.calculator.numScreen.value=str; 
} 
function clearscreen(){ 
num=0; 
result=0; 
numshow="0"; 
document.calculator.numScreen.value="0"; 
} 
function plus(){ 
calculate(); 
operate=1;  
calcul=1;  
} 
function minus(){ 
calculate(); 
operate=1; 
calcul=2; 
} 
function times(){ 
calculate(); 
operate=1; 
calcul=3; 
} 
function divide(){ 
calculate(); 
operate=1; 
calcul=4; 
} 
function persent(){ 
calculate(); 
operate=1; 
calcul=5; 
} 
function equal(){ 
calculate(); 
operate=1; 
num=0; 
result=0; 
numshow="0"; 
} 
// 
function calculate(){ 
numshow=Number(document.calculator.numScreen.value); 
if(num!=0 && quit!=1){ 
switch(calcul){ 
case 1:result=num+numshow;break; 
case 2:result=num-numshow;break;  
case 3:result=num*numshow;break; 
case 4:if(numshow!=0){result=num/numshow;}else{document.getElementById("note").innerHTML="被除数不能为零！"; setTimeout(clearnote,4000)} break; 
case 5:result=num%numshow;break; 
} 
quit=1;
} 
else{ 
result=numshow; 
} 
numshow=String(result); 
document.calculator.numScreen.value=numshow; 
num=result; 
} 
function clearnote(){  
document.getElementById("note").innerHTML=""; 
} 