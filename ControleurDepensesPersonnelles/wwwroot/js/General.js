function GetTypeDepenses(donnes) {
    var labels = [];
    var taille = donnes.length;
    var i = 0;

    while (i < taille) {
        labels.push(donnes[i].typeDepense);
        i++;
    }

    return labels;
}

function GetValeurs(donnes) {
    var valeurs = [];
    var taille = donnes.length;
    var i = 0;

    while (i < taille) {
        valeurs.push(donnes[i].valeurs);
        i++;
    }

    return valeurs;
}


function GetCouleurs(qtd) {
    var couleurs = [];

    while (qtd > 0) {
        var r = Math.floor(Math.random() * 255);
        var g = Math.floor(Math.random() * 255);
        var b = Math.floor(Math.random() * 255);

        couleurs.push("rgb(" + r + "," + g + "," + r + ")");

        qtd--;
    }
    return couleurs;
}

