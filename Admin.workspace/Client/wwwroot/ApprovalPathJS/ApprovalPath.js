function ShoeHideDivById(id) {
    
    var e = document.getElementById(`${id}`)

    if (e.style.display === "none") {
        e.style.display = "block";
    } else {
        e.style.display = "none";
    }
}

function createAlert(id) {

    alert(`${id}`)
}

function swapInnerText(text1, text2, elementId) {
    var current = document.getElementById(`${elementId}`).innerText;
    if (document.getElementById(`${elementId}`).innerText === text1) {
        document.getElementById(`${elementId}`).innerText = text2;
        current = text1;
    } else {
        document.getElementById(`${elementId}`).innerText = text1;
        current = text2;
    }
    return current;
}