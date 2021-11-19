export function upSort(peopleList) {
    return async dispatch => {
        var sortarr = []
        for (var i = 0; i < peopleList.length; i++) {
            for (var j = 0; j < peopleList.length - i - 1; j++) {
                if (peopleList[j + 1].name> peopleList[j].name) {
                    var temp;
                    temp = peopleList[j];
                    peopleList[j] = peopleList[j + 1];
                    peopleList[j + 1] = temp;
                }
            }
            sortarr.push(temp)
        }
        console.log('sortarr asc: ', sortarr);
    };
}
export function downSort(peopleList) {
    return async dispatch => {
        var sortarr2 = []
        for (var i = 0; i < peopleList.length; i++) {
            for (var j = 0; j < peopleList.length - i - 1; j++) {
                if (peopleList[j + 1].name < peopleList[j].name) {
                    var temp;
                    temp = peopleList[j];
                    peopleList[j] = peopleList[j + 1];
                    peopleList[j + 1] = temp;
                }
            }
            sortarr2.push(temp)
        }
        console.log('sortarr2 desc: ', sortarr2);
    };
}
function changeSort(peoplesList) {
    return {
        type: TYPES.PATIENTS_LIST,
        text: peoplesList
    };
}