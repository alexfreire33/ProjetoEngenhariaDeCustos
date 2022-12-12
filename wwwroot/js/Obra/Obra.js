var idParam;
var jsonListaPadrao;
var urlEnvio = "Inserir";//por padrão a variavel chama a action inserir

populaListagem();//carrega a lista com os eventos

//#region Ao digitar o CEP, preencher automaticamente os campos 
jQuery('#obra_Cep').focusout(function () {

    var cep = jQuery(this).val();
    cep = cep.replace(/[^0-9]/g, '');
    cep = parseInt(cep);

    $.getJSON("https://viacep.com.br/ws/" + cep + "/json", function (json) {
        jQuery('#obra_RuaObra').val(json.logradouro);
        jQuery('#obra_BairroObra').val(json.bairro);
        
    });

})
//#endregion

//#region carrega os campos de estado e cidade
new dgCidadesEstados(
   document.getElementById('obra.EstadoObra'),
   document.getElementById('obra.CidadeObra'),
   true
);
//#endregion

//#region função para popular a listagem dos itens  
function populaListagem() {

    var parametrosListarprincipal = {};
    parametrosListarprincipal.pdata = { dataForm: "" }; // mandar o limite de regidstros que vai trazer e o ofsset

    ajaxSubmitRetornoPost("Listar", parametrosListarprincipal, function (returnValue) {


        try {

            jsonListaPadrao = $.parseJSON(returnValue);

            //#region monta a listagem da tabela

            jQuery('#listagemItem tbody td').remove(); //remove do htm pra inserir de novo logo abaixo

            for (var a = 0; a < jsonListaPadrao.obras.length; a++) {

                trataValorNull(jsonListaPadrao.obras);//aqui coloca um texto em valores que vem null no json

                jQuery("#listagemItem tbody").append("\
                    <tr>\
                        <td><font>" + jsonListaPadrao.obras[a]['CodObra'] + "</font></td>\
                        <td><font>" + jsonListaPadrao.obras[a]['NomeObra'] + "</font></td>\
                        <td class='center'>\
                            <input type='hidden' class='cod_item' value='" + JSON.stringify(jsonListaPadrao.obras[a]) + "'>\
                            <a href='javascript:void(0)' class='item'><i class='fa fa-pencil'></i><a/>\
                        </td>\
                        <td class='center'>\
                            <input type='hidden' class='jsonParaDeletar' value='" + JSON.stringify(jsonListaPadrao.obras[a]) + "'>\
                            <a href='javascript:void(0)' class='valores_deletar'><i class='fa fa-close c_red'></i><a/>\
                        </td>\
                    </tr>\
        ");
            }

            //#endregion

            //#region monta o select de construtor

            var options2 = $("#obra\\.TbConstrutorCodConstrutor");//essas \\ é para não da problema porque o id tem . no nome
            for (var it = 0; it < jsonListaPadrao.construtores.length; it++) {

                options2.append($("<option />").val(jsonListaPadrao.construtores[it].CodConstrutor).text(jsonListaPadrao.construtores[it].NomeConstrutor));
            }

            //#endregion

            //#region monta o select de tipologia

            var options3 = $("#obra\\.TbTipologiaCodTipologia");//essas \\ é para não da problema porque o id tem . no nome
            for (var it = 0; it < jsonListaPadrao.tipologias.length; it++) {

                options3.append($("<option />").val(jsonListaPadrao.tipologias[it].CodTipologia).text(jsonListaPadrao.tipologias[it].NomeTipologia));
            }

            //#endregion


        } catch (e) {
            jQuery('#listagemItem tbody td').remove(); //remove do htm pra inserir_imagem de novo logo abaixo

        }

    });

    //jQuery("#detalhesPedido").show(); //mostra a lista

}
//#endregion

//#region editar
jQuery("body").on("click", ".item", function () {

    jQuery("#editarItem").show(); //mostra o botão de editar
    jQuery("#salvarItem").hide(); //esconde o botão de salvar
    jQuery("#cancelaEditar").show(); //mostra o botão de cancelar editar

    var itemFiltrado = jQuery.parseJSON(jQuery(this).parent().find('.cod_item').val());//da o parse para transformar em vetor

    $('#obra\\.TbConstrutorCodConstrutor').val(itemFiltrado.TbConstrutorCodConstrutor).change();
    $('#obra\\.TbTipologiaCodTipologia').val(itemFiltrado.TbTipologiaCodTipologia).change();

    montaCamposEditar(itemFiltrado, "#dadosItem .group-item");//esta função está em /view/util/funcoes.js, e serve para preencher automaticamente os campos do formulario com os valores que estão no json

    jQuery("#obra_CodObra").val(itemFiltrado.CodObra);//coloca no hidden o codigo a ser editado

    urlEnvio = "Editar";//essa variavel ta no começo do código em variaveis globais
});
//#endregion

//#region cancelar o editar
jQuery("#cancelaEditar").on("click", function () {
    location.reload();
});
//#endregion

//#region deletar

jQuery("body").on("click", ".valores_deletar", function () {

    var itemFiltradoParaDelete = jQuery.parseJSON(jQuery(this).parent().find('.jsonParaDeletar').val());//da o parse para transformar em vetor

    swal({
        title: "Deletar Status",
        text: "Tem certeza que você deseja deletar este item? Esta ação não poderá ser desfeita!",
        type: "info",
        showCancelButton: true,
        closeOnConfirm: false,
        showLoaderOnConfirm: true,
    },
        function () {

            urlEnvio = "Deletar";//essa variavel ta no começo do código em variaveis globais

            jQuery("#obra_CodObra").val(itemFiltradoParaDelete.CodObra);//coloca no hidden o codigo a ser editado

            $('#formBasico').submit();

            return false;
        });
});

//#endregion

//#region envia via ajax a requisição

$("#formBasico").on('submit', (function (e) {

    try {

        e.preventDefault();

        var objAjax = new Object();

        objAjax.urlx = urlEnvio;
        objAjax.data = $('#formBasico').serialize();
        objAjax.async = true;

        ajaxBase(objAjax, function (retornoAlertBase) {//chama a função base pra enviar ajax e jogar o alert na tela

            urlEnvio = "Inserir";//coloca o valor inserir na variavel pra deixar com o valor default e mandar pra action de inserir

            if (retornoAlertBase) {
                populaListagem();
            }

        }); //esta função ajaxBase está na pasta view/util/funcoes

        urlEnvio = "Inserir";//coloca o valor inserir na variavel pra deixar ocm o valor default 


    } catch (e) {

        urlEnvio = "Inserir";//coloca o valor inserir na variavel pra deixar ocm o valor default 

    }

}));
//#endregion
