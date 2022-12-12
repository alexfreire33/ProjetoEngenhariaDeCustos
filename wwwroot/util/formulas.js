
/* Objeto */

var objFormula = {

    /*QtAmbGeral = QtAmbPav x QtPavUC x QtUCEmpreend*/

    repeticoesAmbiente: function (objeto) {
        return (objeto.QtAmbPav * objeto.QtPavUC * objeto.QtUCEmpreend);
    },

    perimetroAmbiente: function (objeto) {

        /*PerPisoAmb = ( larg + L ) x 2 - LDescPiso*/

        return ((parseFloat(objeto.larg) + parseFloat(objeto.L)) * 2 - parseFloat(objeto.LDescPiso));
    },

    perimetroObra: function (objeto) {

        /* PerPisoGeral = PerPisoAmb x QtAmbGeral*/

        return (parseFloat(objeto.PerPisoAmb) * parseFloat(objeto.QtAmbGeral));
    },

    areaAmbiente: function (objeto) {

        /*ArPisoAmb = ( larg x L ) - ArDescPiso*/

        return ((parseFloat(objeto.larg) * parseFloat(objeto.L)) - parseFloat(objeto.ArDescPiso));
    },

    areaObra: function (objeto) {

        /*ArPisoGeral = ArPisoAmb x QtAmbGeral*/

        return (parseFloat(objeto.ArPisoAmb) * parseFloat(objeto.QtAmbGeral));
    },

};
