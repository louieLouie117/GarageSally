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
    alert("sign in to get directions");
}