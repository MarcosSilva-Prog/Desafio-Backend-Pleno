// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function mostrarImagem(img) {
    const imagemGrande = document.getElementById("imagemGrande");
    imagemGrande.src = img.src;
    imagemGrande.parentElement.style.display = "block";
}

