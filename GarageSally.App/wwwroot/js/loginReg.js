// users form
const Step1Reg = (e) => {
	document.getElementById("section1Reg").style.display = "grid";
	document.getElementById("section2Reg").style.display = "none";
	document.getElementById("section3Reg").style.display = "none";
	document.getElementById("section4Reg").style.display = "none";
	document.getElementById("sectionHeading").innerText = "Start searching for free.";
};


const Step2Reg = (e) =>{
    document.getElementById("section1Reg").style.display = "none";
    document.getElementById("section2Reg").style.display = "grid";
    document.getElementById("section3Reg").style.display = "none";
    document.getElementById("section4Reg").style.display = "none";
    document.getElementById("sectionHeading").innerText = "Create a password, login to your account in anytime."


}


const Step3Reg = (e) =>{

    document.getElementById("section1Reg").style.display = "none";
    document.getElementById("section2Reg").style.display = "none";
    document.getElementById("section3Reg").style.display = "grid";
    document.getElementById("section4Reg").style.display = "none";
    document.getElementById("sectionHeading").innerText = "Final Step."

 


}


const Step4Reg = (e) => {
	document.getElementById("section1Reg").style.display = "none";
	document.getElementById("section2Reg").style.display = "none";
	document.getElementById("section3Reg").style.display = "none";
	document.getElementById("section4Reg").style.display = "grid";
	document.getElementById("sectionHeading").innerText = "Congratulation";
};




// sellers form
const Step1SellerReg = (e) => {
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
    document.getElementById("sellerHeading").innerText = "Congratulation, Garage Sally is available in your area, start your account."

    document.querySelector('#Redgister').innerHTML = "registerSeller"


}


const Step3SellerReg = (e) =>{
    document.getElementById("section1SellerReg").style.display = "none";
    document.getElementById("section2SellerReg").style.display = "none";
    document.getElementById("section3SellerReg").style.display = "grid";
    document.getElementById("section4SellerReg").style.display = "none";
    document.getElementById("sellerHeading").innerText = "Create a password, login to your account in anytime."


}


const Step4SellerReg = (e) => {
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



const BuyerStateHandler =(e)=>{
    let stateSelected = document.getElementById("BuyerStateSelectionList").value;

    document.getElementById("BuyerState").value = stateSelected;
    console.log(stateSelected);


}

const SellerStateHandler =(e)=>{
    let stateSelected = document.getElementById("SellerSateSelectionList").value;

    document.getElementById("SellerState").value = stateSelected;
    console.log(stateSelected);


}


const SearchTypeHandler =(e)=>{
    if(e.target.innerText === "zip code"){
        document.querySelector("#SearchCityForm").style.display = "none"
        document.querySelector("#SearchZipCode").style.display = "grid"

        document.querySelector("#zipcodeBTN").style.color = "#B936D2"
        document.querySelector("#cityBTN").style.color = "black"



    }
    if(e.target.innerText === "city"){
        document.querySelector("#SearchCityForm").style.display = "grid"
        document.querySelector("#SearchZipCode").style.display = "none"

        document.querySelector("#cityBTN").style.color = "#B936D2"
        document.querySelector("#zipcodeBTN").style.color = "black"
    }


}