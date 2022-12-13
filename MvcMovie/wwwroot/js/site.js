// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// document.getElementById("pictureForm").addEventListener('submit', (e) => submitForm(e))
// document.getElementById("uploadBox").addEventListener('change', (e) => prepImg(e))
// console.log("wqwe")

const submitForm = (e) => {
    e.target.preventDefault();
    if (prepImg) {
        e.target.submit();
    }
    e.target.stopPropagation();
}

const prepImg = (e) => {
    const inputBox = e.target;

    if (!inputBox.files) {

        return null;
    }
    const picfile = inputBox.files[0]
    if (!validateImg(picfile)) {

        return null;
    }

    const imageBlob = new Blob([picfile]);

    return imageBlob;
}

const loadImage = () => {

}

const createImage = (picfile) => {
    const img = document.createElement("img");
    img.id = "imgToUpload";
    img.src = URL.createObjectURL(picfile);
    return img;
}

const validateImg = (pic) => {
    if (pic.type === "image/png" || pic.type === "image/jpeg") {
        return true;
    }
    return false;
}
