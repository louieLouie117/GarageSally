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

const SignInDirectionsHandler = (e) =>{

  
    if(e.target.innerText === "register"){
        document.querySelector("#FreeAccount").style.left ="0%"
        document.querySelector("#FreeAccount").style.transition = "1s";
        document.querySelector("#FreeAccount").style.transform = "smooth";
        document.querySelector("#regNewUserHeading").innerText = "Create a free account and find garage sales in your state."
    }

    if(e.target.innerText === "Directions"){
        document.querySelector("#FreeAccount").style.left ="0%"
        document.querySelector("#FreeAccount").style.transition = "1s";
        document.querySelector("#FreeAccount").style.transform = "smooth";
        document.querySelector("#regNewUserHeading").innerText = "Register for a free account and get access to directions."
        
    }
    if(e.target.innerText === "Register as a new user."){
        document.querySelector("#FreeAccount").style.left ="0%"
        document.querySelector("#FreeAccount").style.transition = "1s";
        document.querySelector("#FreeAccount").style.transform = "smooth";
        document.querySelector("#regNewUserHeading").innerText = "Become a new member of Garage Sally community."

    }

    if(e.target.innerText === "share"){
        alert("Please copy and share this message on your favorite social media? I just found this free website www.garagesally.com to post, find, and share garage sales in our community. ");
    }

}


const SignBackInHandler = (e) =>{
    document.querySelector("#FreeAccount").style.left ="-1000%"
    document.querySelector("#FreeAccount").style.transition = "1s";
    document.querySelector("#FreeAccount").style.transform = "smooth";
    document.getElementById("logInState").style.marginTop = "0";
    document.getElementById("logInState").style.transition = "1s";
    document.getElementById("logInState").style.transform = "smooth";
}

const SearchStateHandler = (e) =>{
    let stateSelected = document.querySelector("#SearchSateSelectionList").value;
    document.getElementById("logInState").style.transition = "1s";
    document.getElementById("logInState").style.transform = "smooth";

    document.querySelector("#StateSearch").value = stateSelected;
    console.log(stateSelected);

}