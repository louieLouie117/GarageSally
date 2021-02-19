// show the text and button options
function step1UserInfo(e) {
    document.getElementById("user-container").style.display = "grid";
    document.getElementById("address-container").style.display = "none";
    document.getElementById("userPhoto-container").style.display = "none";

};


const step2UserPhoto = () =>{
    document.getElementById("user-container").style.display = "none";
    document.getElementById("userPhoto-container").style.display = "grid";
    document.getElementById("address-container").style.display = "none";


}



function step3ZipCode(e) {
    document.getElementById("user-container").style.display = "none";
    document.getElementById("address-container").style.display = "none";
    document.getElementById("userPhoto-container").style.display = "none";
    document.getElementById("address-container").style.display = "grid";

    
};