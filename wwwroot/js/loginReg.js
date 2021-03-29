// users form
function Step1Reg(e) {
    document.getElementById("section1Reg").style.display = "grid";
    document.getElementById("section2Reg").style.display = "none";
    document.getElementById("section3Reg").style.display = "none";
    document.getElementById("section4Reg").style.display = "none";
    document.getElementById("sectionHeading").innerText = "Start searching for free."
    

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




// sellers form
function Step1SellerReg(e) {
    document.getElementById("section1SellerReg").style.display = "grid";
    document.getElementById("section2SellerReg").style.display = "none";
    document.getElementById("section3SellerReg").style.display = "none";
    document.getElementById("section4SellerReg").style.display = "none";
    document.getElementById("sellerHeading").innerText = "Check your area availability."
    

};


const Step2SellerReg = (e) =>{
    document.getElementById("section1SellerReg").style.display = "none";
    document.getElementById("section2SellerReg").style.display = "grid";
    document.getElementById("section3SellerReg").style.display = "none";
    document.getElementById("section4SellerReg").style.display = "none";
    document.getElementById("sellerHeading").innerText = "Congratulation, garageSally is available in your area, create your account."

    document.querySelector('#Redgister').innerHTML = "registerSeller"


}


const Step3SellerReg = (e) =>{
    document.getElementById("section1SellerReg").style.display = "none";
    document.getElementById("section2SellerReg").style.display = "none";
    document.getElementById("section3SellerReg").style.display = "grid";
    document.getElementById("section4SellerReg").style.display = "none";
    document.getElementById("sellerHeading").innerText = "Customize your profile."


}


function Step4SellerReg(e) {
    document.getElementById("section1SellerReg").style.display = "none";
    document.getElementById("section2SellerReg").style.display = "none";
    document.getElementById("section3SellerReg").style.display = "none";
    document.getElementById("section4SellerReg").style.display = "grid";
    document.getElementById("sellerHeading").innerText = "Last step."


    
};





const ShowLogin = ()=>{
    
    document.getElementById("logInState").style.marginTop = "0";
    document.getElementById("logInState").style.transition = "1s";
    document.getElementById("logInState").style.transform = "smooth";


}

const HideLogin = ()=>{
    
    document.getElementById("logInState").style.marginTop = "-1500px";
    document.getElementById("logInState").style.transition = "1s";
    document.getElementById("logInState").style.transform = "smooth";

}

