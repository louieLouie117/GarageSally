// show the text and button options
function Step1Reg(e) {
    document.getElementById("section1Reg").style.display = "grid";
    document.getElementById("section2Reg").style.display = "none";
    document.getElementById("section3Reg").style.display = "none";
    document.getElementById("section4Reg").style.display = "none";
    document.getElementById("sectionHeading").innerText = "Customize your profile."
    

};


const Step2Reg = () =>{
    document.getElementById("section1Reg").style.display = "none";
    document.getElementById("section2Reg").style.display = "grid";
    document.getElementById("section3Reg").style.display = "none";
    document.getElementById("section4Reg").style.display = "none";
    document.getElementById("sectionHeading").innerText = "Create a password, login to your account in anytime."


}


const Step3Reg = () =>{
    document.getElementById("section1Reg").style.display = "none";
    document.getElementById("section2Reg").style.display = "none";
    document.getElementById("section3Reg").style.display = "grid";
    document.getElementById("section4Reg").style.display = "none";
    document.getElementById("sectionHeading").innerText = "Customize your profile."


}


function Step4Reg(e) {
    document.getElementById("section1Reg").style.display = "none";
    document.getElementById("section2Reg").style.display = "none";
    document.getElementById("section3Reg").style.display = "none";
    document.getElementById("section4Reg").style.display = "grid";
    document.getElementById("sectionHeading").innerText = "Congratulation"


    
};