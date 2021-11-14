function Clear() {
    document.getElementById("name").value = "";
    document.getElementById("addCity").selectedIndex = 0;
    console.log(document.getElementById("selectCity").value);
    document.getElementById("phone").value = "";
}


function showDiv(p) {

    // clear select
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
    document.getElementById("editPhoneNumber").value = p.teleNumber;

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
}


//for ajax controller
function personShow() {

    $.ajax({
        type: "GET",
        url: "Ajax/People",
        success: function (output) {
            //console.log(output);
            document.getElementById("showResult").innerHTML = output;

        },
        error: function (output) {
            alert(output.status + " :" + output.responseText);
        }
    })
}

function personDetails() {
    var id = document.getElementById("personId").value;
    /* console.log(!id);*/
    if (id) {
        $.ajax({
            type: "GET",
            url: `Ajax/Details/${id}`,
            success: function (output) {
                document.getElementById("showResult").innerHTML = output;

            },
            error: function (output) {
                alert(output.status + " :" + output.responseText);
            }
        })
    }
    else {
        $.ajax({
            type: "GET",
            url: "Ajax/Error",
            success: function (output) {
                document.getElementById("showResult").innerHTML = output;

            },
            error: function (output) {
                alert(output.status + " :" + output.responseText);
            }
        })
    }
}


function personDelete() {
    var id = document.getElementById("personId").value
    $.ajax({
        type: "GET",
        url: `Ajax/Delete/${id}`,
        success: function (output) {
            console.log(output);
            document.getElementById("showResult").innerHTML = output;
        },
        error: function (output) {
            console.log(output.status + " :" + output.responseText);
        }
    })
}

tail.select("#addCity", {
});
tail.select("#selectLanguage", {
});
