// show the text and button options

// Variable for menu
let menu = "close"

const showMainMenu =(e) => {

        console.log(e);
        if (menu === "close") {     
        document.getElementById("mainMenu").style.height = "95vh";
        document.getElementById("mainMenu").style.width = "42vh";
        document.getElementById("mainMenu").style.margin = "0px";
        document.getElementById("mainMenu").style.borderRadius = "0";
        document.getElementById("mainMenu").style.transform = "smooth";
        document.getElementById("mainMenu").style.transition = ".5s";
        document.getElementById("mainMenu").style.padding = "30px";
        document.getElementById("mainMenu").style.boxShadow = "5px 0px 20px rgba(0, 0, 0, 0.501)";
        console.log("inside the if stament",menu);
        return (menu = "open");


    }else {      
        document.getElementById("mainMenu").style.height = "40px";
        document.getElementById("mainMenu").style.width = "40px";
        document.getElementById("mainMenu").style.margin = "20px";
        document.getElementById("mainMenu").style.borderRadius = "40px";
        document.getElementById("mainMenu").style.transform = "smooth";
        document.getElementById("mainMenu").style.transition = ".5s";
        document.getElementById("mainMenu").style.padding = "10px";
        document.getElementById("mainMenu").style.boxShadow = "0px 0px 5px rgba(0, 0, 0, 0.734)";

    

        return (menu = "close");

    }

        
};

let profilePage = "close"

const profile = (e) =>{

    if (profilePage === "close") { 
    document.getElementById("profile").style.marginLeft = "0";
    document.getElementById("profile").style.transform = "smooth";
    document.getElementById("profile").style.transition = "1s";
    document.getElementById("mainMenu").style.marginLeft = "-700px";


    return (profilePage = "open")

    } else{
    document.getElementById("profile").style.marginLeft = "-700px";
    document.getElementById("profile").style.transform = "smooth";
    document.getElementById("profile").style.transition = "1s";
    document.getElementById("mainMenu").style.marginLeft = "0";

    return (profilePage = "close");
    }
// Page

}


let postSaleEvent = "close"

const postSalePartialHandler = (e) =>{

    if (postSaleEvent === "close") { 
    document.getElementById("postSalePartial").style.marginLeft = "0";
    document.getElementById("postSalePartial").style.transform = "smooth";
    document.getElementById("postSalePartial").style.transition = "1s";
    document.getElementById("mainMenu").style.marginLeft = "-700px";

    let streetNumber = document.getElementById("StreetNumberEdit").value;
    let streetName = document.getElementById("StreetNameEdit").value;
    let city = document.getElementById("CityEdit").value;
    let state = document.getElementById("StateEdit").value;
    let zipcode = document.getElementById("ZipcodeEdit").value;


    document.getElementById("StreetNumber").value = streetNumber;
    document.getElementById("StreetName").value = streetName;
    document.getElementById("City").value = city;
    document.getElementById("State").value = state;
    document.getElementById("Zipcode").value = zipcode;



    return (postSaleEvent = "open")

    } else{
    document.getElementById("postSalePartial").style.marginLeft = "-700px";
    document.getElementById("postSalePartial").style.transform = "smooth";
    document.getElementById("postSalePartial").style.transition = "1s";
    document.getElementById("mainMenu").style.marginLeft = "0";

    return (postSaleEvent = "close");
    }
// Page

}



let aboutGarageSallyEvent = "close"

const aboutGarageSallyHandler = (e) =>{

    if (aboutGarageSallyEvent === "close") { 
    document.getElementById("aboutGarageSallyPartial").style.marginLeft = "0";
    document.getElementById("aboutGarageSallyPartial").style.transform = "smooth";
    document.getElementById("aboutGarageSallyPartial").style.transition = "1s";
    document.getElementById("mainMenu").style.marginLeft = "-700px";


    return (aboutGarageSallyEvent = "open")

    } else{
    document.getElementById("aboutGarageSallyPartial").style.marginLeft = "-700px";
    document.getElementById("aboutGarageSallyPartial").style.transform = "smooth";
    document.getElementById("aboutGarageSallyPartial").style.transition = "1s";
    document.getElementById("mainMenu").style.marginLeft = "0";

    return (aboutGarageSallyEvent = "close");
    }
// Page

}

let privacyPolicyEvent = "close"

const privacyPolicyHandler = (e) =>{

    if (privacyPolicyEvent === "close") { 
    document.getElementById("privacyPolicyPartial").style.marginLeft = "0";
    document.getElementById("privacyPolicyPartial").style.transform = "smooth";
    document.getElementById("privacyPolicyPartial").style.transition = "1s";
    document.getElementById("mainMenu").style.marginLeft = "-700px";


    return (privacyPolicyEvent = "open")

    } else{
    document.getElementById("privacyPolicyPartial").style.marginLeft = "-700px";
    document.getElementById("privacyPolicyPartial").style.transform = "smooth";
    document.getElementById("privacyPolicyPartial").style.transition = "1s";
    document.getElementById("mainMenu").style.marginLeft = "0";

    return (privacyPolicyEvent = "close");
    }
// Page

}



let termsOfServiceEvent = "close"

const termsOfServiceHandler = (e) =>{

    if (termsOfServiceEvent === "close") { 
    document.getElementById("termsOfServicePartial").style.marginLeft = "0";
    document.getElementById("termsOfServicePartial").style.transform = "smooth";
    document.getElementById("termsOfServicePartial").style.transition = "1s";
    document.getElementById("mainMenu").style.marginLeft = "-700px";


    return (termsOfServiceEvent = "open")

    } else{
    document.getElementById("termsOfServicePartial").style.marginLeft = "-700px";
    document.getElementById("termsOfServicePartial").style.transform = "smooth";
    document.getElementById("termsOfServicePartial").style.transition = "1s";
    document.getElementById("mainMenu").style.marginLeft = "0";

    return (termsOfServiceEvent = "close");
    }
// Page

}



let updatesSupportEvent = "close"

const updatesSupportHandler = (e) =>{
    alert("button was click")

    if (updatesSupportEvent === "close") { 
    document.getElementById("updatesSupportPartial").style.marginLeft = "0";
    document.getElementById("updatesSupportPartial").style.transform = "smooth";
    document.getElementById("updatesSupportPartial").style.transition = "1s";
    document.getElementById("mainMenu").style.marginLeft = "-700px";


    return (updatesSupportEvent = "open")

    } else{
    document.getElementById("updatesSupportPartial").style.marginLeft = "-700px";
    document.getElementById("updatesSupportPartial").style.transform = "smooth";
    document.getElementById("updatesSupportPartial").style.transition = "1s";
    document.getElementById("mainMenu").style.marginLeft = "0";

    return (updatesSupportEvent = "close");
    }
// Page

}


const popUpNoticeHandler = (e) => {
    if(e.target.innerText === "Change Photo"){
        document.getElementById("photoUploadNotice").style.display = "grid";
    }

    if(e.target.innerText === "Upgrade Account"){
        document.getElementById("upgradeNotice").style.display = "grid";
        let zipcode = document.getElementById("ZipcodeEdit").value;
        console.log("zipcode",zipcode);

    }
    
    if(e.target.innerText === "Cancel"){
        document.getElementById("photoUploadNotice").style.display = "none";
        document.getElementById("upgradeNotice").style.display = "none";

    }


}

const profileNav =(e)=>{
    console.log(e.target.innerText)

    if(e.target.innerText === "your post"){
        document.getElementById("postForm").style.display = "none";
        document.getElementById("usersGarageSalesPartial").style.display = "grid";
        document.getElementById("recentPostOption").style.borderBottom = "#b936d2 solid 2px";    
        document.getElementById("newSaleOption").style.borderBottom = "none";


    }else{
        document.getElementById("postForm").style.display = "grid";
        document.getElementById("usersGarageSalesPartial").style.display = "none";
        document.getElementById("newSaleOption").style.borderBottom = "#b936d2 solid 2px";    
        document.getElementById("recentPostOption").style.borderBottom = "none";
    }
}








//Modify how to create a website article--------------------------------------------------->
// let readMeV = "open";

// document
//   .getElementById("readWebsiteBTN")
//   .addEventListener("click", showWebBlog);

// function showWebBlog(e) {
//   if (readMeV == "open") {
//     document.getElementById("openBlog").style.height = "auto";
//     document.getElementById("readWebsiteBTN").innerText = "Close Article";
//     return (readMeV = "close");
//   } else {
//     document.getElementById("openBlog").style.height = "117px";
//     document.getElementById("readWebsiteBTN").innerText = "Read Article";
//     return (readMeV = "open");
//   }
// }



// function hideMainMenu(e) {
//     document.getElementById("mainMenu").style.transition = "smooth";
//     document.getElementById("mainMenu").style.transition = "1s";
    
// };


// // show the text and button options
// function showMainMenu(e) {
    
//     document.getElementById("mainMenu").style.height = "100%";
//     document.getElementById("mainMenu").style.width = "90%";
//     document.getElementById("mainMenu").style.margin = "0";
//     document.getElementById("mainMenu").style.borderRadius = "0";
//     document.getElementById("mainMenu").style.transition = "smooth";
//     document.getElementById("mainMenu").style.transition = "2s";
        
// };


// function hideMainMenu(e) {
//     document.getElementById("mainMenu").style.transition = "smooth";
//     document.getElementById("mainMenu").style.transition = "1s";
    
// };