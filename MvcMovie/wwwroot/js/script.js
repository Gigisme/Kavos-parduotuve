const form = document.getElementById("picform");
const input = document.getElementById("picfile");

const imageChange = (file) => {
    const blob = new Blob([file]);
    console.log(blob.size)

    // const reader = new FileReader();
    // reader.readAsArrayBuffer(file);

    // reader.onload = function() {
    // const blob = new Blob([file]);
    // console.log(blob.text().then((v) => console.log(v)))
    //};
}

input.addEventListener("change", (e) => {
    let existingdisplayElement = document.getElementById("displayElement");
    if (existingdisplayElement) {
        document.getElementById("displayElement").remove();
    }

    if (input && input.files[0]) {
        const file = input.files[0];
        //console.log(file)
        const fileKbSize = (input.files[0].size / 1024).toFixed(2);

        if (file.type === "image/png" || file.type === "image/jpeg") {

            const img = document.createElement("img");
            img.id = "imgToUpload";
            img.src = URL.createObjectURL(input.files[0]);

            img.height = 50;
            img.style.display = "none";
            img.addEventListener("loadstart", (e) => {

            })

            img.addEventListener("load", (e) => {
                e.target.style.display = "block"
                console.log(e.target)
                imgOut = e.target;
                URL.revokeObjectURL(this.src);
                let displayElement = document.createElement("div")
                displayElement.id = "displayElement";
                let displayContent = `${imgOut.outerHTML} <div> Kb size: ${fileKbSize} </div>`;
                displayElement.innerHTML = `<span>${displayContent}</span>`
                document.body.appendChild(displayElement)

            })

            imageChange(file);

        } else {
            displayContent = "please select an image file"
        }
    }
})

form.addEventListener("submit", (e) => {
    e.preventDefault();
    const formData = new FormData(form);
    const pic = formData.get("fileatt");
}
)


