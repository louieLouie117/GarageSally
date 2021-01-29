// show the text and button options

// Variable for menu
let menu = "close"

const showMainMenu =(e) => {
        console.log(e);
        if (menu === "close") {     
        document.getElementById("mainMenu").style.height = "100%";
        document.getElementById("mainMenu").style.width = "80%";
        document.getElementById("mainMenu").style.margin = "0px";
        document.getElementById("mainMenu").style.borderRadius = "0";
        document.getElementById("mainMenu").style.transition = "smooth";
        document.getElementById("mainMenu").style.transition = "1.5s";
        document.getElementById("mainMenu").style.padding = "30px";
        console.log("inside the if stament",menu);
        return (menu = "open");


    }else {
            
        document.getElementById("mainMenu").style.height = "40px";
        document.getElementById("mainMenu").style.width = "40px";
        document.getElementById("mainMenu").style.margin = "20px";
        document.getElementById("mainMenu").style.borderRadius = "40px";
        document.getElementById("mainMenu").style.transition = "smooth";
        document.getElementById("mainMenu").style.transition = "1.5s";
        document.getElementById("mainMenu").style.padding = "10px";
        return (menu = "close");

    }

        
};


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