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


const DateSelectedHandler = (e) =>{

    const DateFormat = {
        weekday: "long",
        month: "long",
        day: "numeric"
    };
  
  let OneDayAfter =  new Date(e.target.value)
  OneDayAfter.setDate(OneDayAfter.getDate() + 2);

  let TwoDaysAfter =  new Date(e.target.value)
  TwoDaysAfter.setDate(TwoDaysAfter.getDate() + 3);

  let ThreeDaysAfter =  new Date(e.target.value)
  ThreeDaysAfter.setDate(ThreeDaysAfter.getDate() + 4);

  let FourDaysAfter =  new Date(e.target.value)
  FourDaysAfter.setDate(FourDaysAfter.getDate() + 5);

  let FiveDaysAfter =  new Date(e.target.value)
  FiveDaysAfter.setDate(FiveDaysAfter.getDate() + 6);

  let SixDaysAfter =  new Date(e.target.value)
  SixDaysAfter.setDate(SixDaysAfter.getDate() + 7);

  let SevenDaysAfter =  new Date(e.target.value)
  SevenDaysAfter.setDate(SevenDaysAfter.getDate() + 8);



    document.getElementById("1DayFromDateSelected").value = OneDayAfter.toLocaleDateString("en-US", DateFormat);
    document.getElementById("2DayFromDateSelected").value = TwoDaysAfter.toLocaleDateString("en-US", DateFormat);
    document.getElementById("3DayFromDateSelected").value = ThreeDaysAfter.toLocaleDateString("en-US", DateFormat);
    document.getElementById("4DayFromDateSelected").value = FourDaysAfter.toLocaleDateString("en-US", DateFormat);
    document.getElementById("5DayFromDateSelected").value = FiveDaysAfter.toLocaleDateString("en-US", DateFormat);
    document.getElementById("6DayFromDateSelected").value = SixDaysAfter.toLocaleDateString("en-US", DateFormat);
    document.getElementById("7DayFromDateSelected").value = SevenDaysAfter.toLocaleDateString("en-US", DateFormat);
    console.log(OneDayAfter)


}


const PostToOtherDates =(e) =>{

    if(e.target.innerText === "No, thank you" || e.target.innerText === "Done"  ){

        document.querySelector("#ListSaleDate").style.display = "grid";
        document.querySelector("#multiDayPost").style.display = "none"
        document.querySelector("#NewPostForm").style.display = "grid";
        document.getElementById("postSalePartial").style.marginLeft = "-700px";
        document.getElementById("postSalePartial").style.transform = "smooth";
        document.getElementById("postSalePartial").style.transition = "1s";
        document.getElementById("updatesSupportPartial").style.marginLeft = "0";
        document.getElementById("updatesSupportPartial").style.transform = "smooth";
        document.getElementById("updatesSupportPartial").style.transition = "1s";
        document.getElementById("usersGarageSalesPartial").style.display = "grid";
        document.querySelector("#PostSaleTitle1").innerText = "List your garage sale."

        
        document.querySelector("#OneDayAfterForm").style.marginLeft = "-100%";
        document.getElementById("OneDayAfterForm").style.transform = "smooth";
        document.getElementById("OneDayAfterForm").style.transition = "1s";

        document.querySelector("#TwoDaysAfterForm").style.marginLeft = "-220%";
        document.getElementById("TwoDaysAfterForm").style.transform = "smooth";
        document.getElementById("TwoDaysAfterForm").style.transition = "1.2s";

        document.querySelector("#ThreeDaysAfterForm").style.marginLeft = "-330%";
        document.getElementById("ThreeDaysAfterForm").style.transform = "smooth";
        document.getElementById("ThreeDaysAfterForm").style.transition = "1.3s";


        document.querySelector("#FourDaysAfterForm").style.marginLeft = "-440%";
        document.getElementById("FourDaysAfterForm").style.transform = "smooth";
        document.getElementById("FourDaysAfterForm").style.transition = "1.4s";


        document.querySelector("#FiveDaysAfterForm").style.marginLeft = "-550%";
        document.getElementById("FiveDaysAfterForm").style.transform = "smooth";
        document.getElementById("FiveDaysAfterForm").style.transition = "1.5s";

        document.querySelector("#SixDaysAfterForm").style.marginLeft = "-660%";
        document.getElementById("SixDaysAfterForm").style.transform = "smooth";
        document.getElementById("SixDaysAfterForm").style.transition = "1.6s";


        document.querySelector("#SevenDaysAfterForm").style.marginLeft = "-770%";
        document.getElementById("SevenDaysAfterForm").style.transform = "smooth";
        document.getElementById("SevenDaysAfterForm").style.transition = "1.7s";



    }
    
    if(e.target.innerText === "Yes"){  

        
        document.querySelector("#OneDayAfterForm").style.marginLeft = "0%";
        document.getElementById("OneDayAfterForm").style.transform = "smooth";
        document.getElementById("OneDayAfterForm").style.transition = "1s";

        document.querySelector("#TwoDaysAfterForm").style.marginLeft = "0%";
        document.getElementById("TwoDaysAfterForm").style.transform = "smooth";
        document.getElementById("TwoDaysAfterForm").style.transition = "1.2s";

        document.querySelector("#ThreeDaysAfterForm").style.marginLeft = "0%";
        document.getElementById("ThreeDaysAfterForm").style.transform = "smooth";
        document.getElementById("ThreeDaysAfterForm").style.transition = "1.3s";


        document.querySelector("#FourDaysAfterForm").style.marginLeft = "0%";
        document.getElementById("FourDaysAfterForm").style.transform = "smooth";
        document.getElementById("FourDaysAfterForm").style.transition = "1.4s";


        document.querySelector("#FiveDaysAfterForm").style.marginLeft = "0%";
        document.getElementById("FiveDaysAfterForm").style.transform = "smooth";
        document.getElementById("FiveDaysAfterForm").style.transition = "1.5s";

        document.querySelector("#SixDaysAfterForm").style.marginLeft = "0%";
        document.getElementById("SixDaysAfterForm").style.transform = "smooth";
        document.getElementById("SixDaysAfterForm").style.transition = "1.6s";


        document.querySelector("#SevenDaysAfterForm").style.marginLeft = "0%";
        document.getElementById("SevenDaysAfterForm").style.transform = "smooth";
        document.getElementById("SevenDaysAfterForm").style.transition = "1.7s";
    
        
        document.querySelector("#ListSaleDate").style.display = "none";
        document.querySelector("#PostSaleTitle1").innerText = "+ add to other days."

    }   
    
   
}




let postSaleEvent = "close"

const postSalePartialHandler = (e) =>{


    if(e.target.innerText === "+ Another garage sale"){
        document.getElementById("postSalePartial").style.marginLeft = "0";
        document.getElementById("postSalePartial").style.transform = "smooth";
        document.getElementById("postSalePartial").style.transition = "1s";
        document.getElementById("mainMenu").style.marginLeft = "-700px";
        document.getElementById("updatesSupportPartial").style.marginLeft = "-700px";
        document.getElementById("updatesSupportPartial").style.transform = "smooth";
        document.getElementById("updatesSupportPartial").style.transition = "1s";
        document.getElementById("mainMenu").style.marginLeft = "0";

    };

    if(e.target.innerText === "< back"){
        document.getElementById("postSalePartial").style.marginLeft = "-700px";
        document.getElementById("postSalePartial").style.transform = "smooth";
        document.getElementById("postSalePartial").style.transition = "1s";
        document.getElementById("mainMenu").style.marginLeft = "0";
        
    
        return (postSaleEvent = "close");
        }

    if (e.target.innerText === "Post a sale" || "+") { 
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

    } 


    


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



let salesHistoryEvent = "close"

const SalesHistoryHandler = (e) =>{

    if (salesHistoryEvent === "close") { 
    document.getElementById("updatesSupportPartial").style.marginLeft = "0";
    document.getElementById("updatesSupportPartial").style.transform = "smooth";
    document.getElementById("updatesSupportPartial").style.transition = "1s";
    document.getElementById("mainMenu").style.marginLeft = "-700px";

    document.getElementById("usersGarageSalesPartial").style.display = "grid";


    return (salesHistoryEvent = "open")

    } else{
    document.getElementById("updatesSupportPartial").style.marginLeft = "-700px";
    document.getElementById("updatesSupportPartial").style.transform = "smooth";
    document.getElementById("updatesSupportPartial").style.transition = "1s";
    document.getElementById("mainMenu").style.marginLeft = "0";

    return (salesHistoryEvent = "close");
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
    
    if(e.target.innerText === "Close"){
        document.getElementById("photoUploadNotice").style.display = "none";
        document.getElementById("upgradeNotice").style.display = "none";

    }
    if(e.target.innerText === "share"){
    alert("Please copy and share this message on your favorite social media? I just found this free website www.garagesally.com to post, find, and share garage sales in our community. ");

    }

    if(e.target.innerText === "post"){
        document.getElementById("postSalePartial").style.marginLeft = "0";
        document.getElementById("postSalePartial").style.transform = "smooth";
        document.getElementById("postSalePartial").style.transition = "1s";
        document.getElementById("mainMenu").style.marginLeft = "-700px";
        

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




const ComingSoonNotice = (e) => {
    alert("This feature will be coming in a later version of Garage Sally. Please check back.");
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