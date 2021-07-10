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

const SignInDirectionsHandler = () =>{
    document.querySelector("#FreeAccount").style.left ="0%"
    document.querySelector("#FreeAccount").style.transition = "1s";
    document.querySelector("#FreeAccount").style.transform = "smooth";

}


const SignBackInHandler = (e) =>{
    document.querySelector("#FreeAccount").style.left ="-1000%"
    document.querySelector("#FreeAccount").style.transition = "1s";
    document.querySelector("#FreeAccount").style.transform = "smooth";
    document.getElementById("logInState").style.marginTop = "0";
    document.getElementById("logInState").style.transition = "1s";
    document.getElementById("logInState").style.transform = "smooth";
}