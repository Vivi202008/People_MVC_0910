function Clear() {
    document.getElementById("name").value = "";
    document.getElementById("addCity").selectedIndex = 0;
    console.log(document.getElementById("selectCity").value);
    document.getElementById("phone").value = "";
}

function showDiv(p) {
    // clear
    for (const option of document.querySelectorAll("option.edit[selected]")) {
        option.removeAttribute('selected');
    }
    // select
    for (const element of document.querySelectorAll("span.person-id-" + p.id + ".language")) {
        const option = document.querySelector("option#" + element.innerHTML)
        option.setAttribute('selected', 'selected');
    }

    document.getElementById("editID").value = p.id;
    document.getElementById("editName").value = p.name;
    document.getElementById("editPhoneNumber").value = p.phoneNumber;

    //change the value of drop down list
    var cityList = document.getElementById("selectCity");
    for (var i = 1; i < cityList.options.length; i++) {
        if (cityList.options[i].innerHTML === p.city) {
            cityList.selectedIndex = i;
            break;
        }
    }
}

//Edit country or city
function editLocation(p) {
    document.getElementById("editID").value = p.id;
    document.getElementById("editName").value = p.name;
    document.getElementById("editName1").value = p.name1;
}

tail.select("#addCity", {
});
tail.select("#selectLanguage", {
});
