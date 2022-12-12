
//#region inseri uma linha no log do sistema 

//inseriLog("", "info");//inseri log de erro no sistema, esa função está no arquivo /util/funcoes.js

//#endregion

//#region aqui é a chamada para carregar o oneerror que vai salvar todos os erros de pagina

window.onerror = function (errorMsg, url, lineNumber) {
    // alert('Error: ' + errorMsg + ' Script: ' + url + ' Line: ' + lineNumber);
    //inseriLog(errorMsg, "error", lineNumber);//inseri log de erro no sistema, esa função está no arquivo /util/funcoes.js
}

//#endregion


//#region função base para enviar o ajax e mostrar o swal alert

function ajaxBase(objAjax, retornoBase) {

    var funcao = "ajaxSubmitEntity";

    if (objAjax.enviar_como_imagem) {
        funcao = eval("ajaxSubmitEntityComImagem");
    } else {
        funcao = eval("ajaxSubmitEntity");
    }

    funcao(objAjax, function (returnValue) {

        try {
            var retornoBack = JSON.parse(returnValue);//retorno do controller convertido no json

            if (retornoBack['bool'] == "false") {

                /*essa condicional é para trocar o botão de editar para inserir só quando está editando*/
                if (objAjax.urlx == "Editar") {

                    jQuery("#editarItem").hide();
                    jQuery("#salvarItem").show();
                    jQuery("#cancelaEditar").hide();
                }

                if (typeof objAjax.mensagem == "undefined") {
                    swal("Erro!", retornoBack['retorno'], "error");//("Erro!", data, "error");
                }

                retornoBase(false);

            } else {

                if (typeof objAjax.mensagem == "undefined") {

                    swal(
                        {
                            title: retornoBack['retorno'],
                            type: "success",
                        }, function () {

                            /*essa condicional é para trocar o botão de editar para inserir só quando está editando*/
                            if (objAjax.urlx == "Editar") {

                                jQuery("#editarItem").hide();
                                jQuery("#salvarItem").show();
                                jQuery("#cancelaEditar").hide();

                            }

                            retornoBase(retornoBack);
                        }

                    );
                }

                retornoBase(retornoBack);

            }


        } catch (e) {
            swal("Erro!", "Erro interno, favor entrar em contato com o suporte", "error");//("Erro!", data, "error");
            retornoBase(false);
        }

    }); //esta função ajaxSubmitRetornoPost está na pasta view/util/funcoes



}; //esta função ajaxSubmitRetornoPost está na pasta view/util/funcoes


//#endregion


//#region aqui é a função ajax pra requisição para entity framework
function ajaxSubmitEntity(arg, retorno) {

    $.ajax({


        datype: typeof arg.datype == "undefined" ? "application/x-www-form-urlencoded" : arg.datype,
        contentType: typeof arg.contentType == "undefined" ? "application/x-www-form-urlencoded; charset=UTF-8" : arg.contentType,
        cache: typeof arg.cache == "undefined" ? false : arg.cache,
        type: typeof arg.type == "undefined" ? 'POST' : arg.type,
        url: arg.urlx,
        data: arg.data,
        async: typeof arg.async == "undefined" ? true : arg.async,
        success: retorno,
        error: function (jqXHR, exception) {
            if (jqXHR.status === 0) {
                //alert('Not connect.\n Verify Network.');
                inseriLog("Not connect Verify Network.", "erro");//inseri log no sistema, esa função está no arquivo /util/funcoes.js

                return;
            } else if (jqXHR.status == 404) {
                //alert('Requested page not found. [404]');
                return;
            } else if (jqXHR.status == 500) {
                alert('Internal Server Error [500].');
                return;
            } else if (exception === 'parsererror') {
                alert('Requested JSON parse failed.');
                return;
            } else if (exception === 'timeout') {
                alert('Time out error.');
                return;
            } else if (exception === 'abort') {
                alert('Ajax request aborted.');
                return;
            } else {
                alert('Uncaught Error.\n' + jqXHR.responseText);
                return;
            }

        }
    });
}
//#endregion

//#region aqui é a função ajax pra requisição para entity framework
function ajaxSubmitEntityComImagem(arg, retorno) {

    $.ajax({
        cache: typeof arg.cache == "undefined" ? false : arg.cache,
        type: typeof arg.type == "undefined" ? 'POST' : arg.type,
        url: arg.urlx,
        //datype: typeof arg.datype == "undefined" ? false : arg.datype,
        contentType: typeof arg.contentType == "undefined" ? false : arg.contentType,
        processData: typeof arg.processData == "undefined" ? false : arg.processData,
        data: arg.data,
        async: typeof arg.async == "undefined" ? true : arg.async,
        success: retorno,
        error: function (jqXHR, exception) {
            if (jqXHR.status === 0) {
                //alert('Not connect.\n Verify Network.');
                inseriLog("Not connect Verify Network.", "erro");//inseri log no sistema, esa função está no arquivo /util/funcoes.js

                return;
            } else if (jqXHR.status == 404) {
                //alert('Requested page not found. [404]');
                return;
            } else if (jqXHR.status == 500) {
                alert('Internal Server Error [500].');
                return;
            } else if (exception === 'parsererror') {
                alert('Requested JSON parse failed.');
                return;
            } else if (exception === 'timeout') {
                alert('Time out error.');
                return;
            } else if (exception === 'abort') {
                alert('Ajax request aborted.');
                return;
            } else {
                alert('Uncaught Error.\n' + jqXHR.responseText);
                return;
            }

        }
    });
}
//#endregion


//#region aqui é a função ajax pra requisição get, passa todos os parametros via irl 
function ajaxSubmitRetorno(urlx, retorno) {
    $.ajax({
        cache: true,
        type: 'GET',
        url: urlx,
        contentType: "json",
        async: false,
        success: retorno,
        error: function (jqXHR, exception) {
            if (jqXHR.status === 0) {
                //alert('Not connect.\n Verify Network.');
                inseriLog("Not connect Verify Network.", "erro");//inseri log no sistema, esa função está no arquivo /util/funcoes.js

                return;
            } else if (jqXHR.status == 404) {
                //alert('Requested page not found. [404]');
                return;
            } else if (jqXHR.status == 500) {
                alert('Internal Server Error [500].');
                return;
            } else if (exception === 'parsererror') {
                alert('Requested JSON parse failed.');
                return;
            } else if (exception === 'timeout') {
                alert('Time out error.');
                return;
            } else if (exception === 'abort') {
                alert('Ajax request aborted.');
                return;
            } else {
                alert('Uncaught Error.\n' + jqXHR.responseText);
                return;
            }

        }
    });
}
//#endregion

//#region aqui é a função que faz a requisição via post, precisa passar os parametros em um objeto
function ajaxSubmitRetornoPost(urlx, parametros, retornoPost) {

    $.ajax({
        url: urlx,
        type: 'POST',
        //dataType: 'json',
        data: parametros.pdata,
        async: true,
        cache: true,
        success: retornoPost,
        error: function (jqXHR, exception) {
            if (jqXHR.status === 0) {
                //alert('Not connect.\n Verify Network.');
                inseriLog("Not connect Verify Network.", "erro");//inseri log no sistema, esa função está no arquivo /util/funcoes.js

                return;
            } else if (jqXHR.status == 404) {
                alert('Requested page not found. [404]');
                return;
            } else if (jqXHR.status == 500) {
                alert('Internal Server Error [500].');
                return;
            } else if (exception === 'parsererror') {
                alert('Requested JSON parse failed.');
                return;
            } else if (exception === 'timeout') {
                alert('Time out error.');
                return;
            } else if (exception === 'abort') {
                alert('Ajax request aborted.');
                return;
            } else {
                alert('Uncaught Error.\n' + jqXHR.responseText);
                return;
            }

        }
    });
}
//#endregion 

//#region função que faz a requisição via post, precisa passar os parametros em um json sem parse
function enviaAjaxObjetoJson(urlEnvio, valor, retornoPost) {
    $.ajax({
        url: urlEnvio,
        data: { dados: valor },
        type: 'POST',
        success: retornoPost,
        error: function (jqXHR, exception) {
            if (jqXHR.status === 0) {
                //alert('Not connect.\n Verify Network.');
                inseriLog("Not connect Verify Network.", "erro");//inseri log no sistema, esa função está no arquivo /util/funcoes.js

                return;
            } else if (jqXHR.status == 404) {
                alert('Requested page not found. [404]');
                return;
            } else if (jqXHR.status == 500) {
                alert('Internal Server Error [500].');
                return;
            } else if (exception === 'parsererror') {
                alert('Requested JSON parse failed.');
                return;
            } else if (exception === 'timeout') {
                alert('Time out error.');
                return;
            } else if (exception === 'abort') {
                alert('Ajax request aborted.');
                return;
            } else {
                alert('Uncaught Error.\n' + jqXHR.responseText);
                return;
            }
        }
    });
}
//#endregion 

//#region Funcao para nao permitir digitar numeros // onKeypress="return somenteNumeros(event)"
function somenteNumeros() {
    /*
    if (value == null || !value.toString().match(/^[-]?d*.?d*$/)){
        return false;
    }else{
        return true;
    }
    jQuery(document).ready(function() {
        jQuery(obj).keypress(function() {
            var texto = jQuery(this).val();
            if (somenteNumeros(texto)) {
                jQuery(this).val(texto.substring(0, texto.length));
            }
        });
    });
    */

    var myRegex = new RegExp(/^[a-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÒÖÚÇÑ ]+$/);
    var myArray = myRegex.exec("cd23Áaas");
    console.log(myArray)
};
//var reg = 
//#endregion

//#region Funcao para pegar um paramentro na URL
function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}
//#endregion

//#region redireciona pra pagina escolhida, isso aqui vai ser mudado, por enquanto nos hrefs do sistema manda pra essa função e essa função redireciona pra pagina que foi clicado o href
function redireciona(diretorio) {

    window.location.href = dominioInicial() + diretorio;

}
//#endregion

//#region coloca no storagelocal o valor do dominio inicial
function dominioInicial() {
    //localStorage.removeItem("dominioInicial");

    /* if (sessionStorage.getItem("dominioInicial") === null) {
         sessionStorage.setItem("dominioInicial","http://minhafestaperfeita.com.br/"); //aqui eu dou um replace em index por que precisa pegar so o endereço do dominio
     }*/
    if (location.hostname === "localhost" || location.hostname === "127.0.0.1") {
        return "http://localhost/cervejaevinho.com.br/";

    } else {
        return window.location.protocol + "//" + window.location.host + "/";
    }

}
//#endregion

//#region verifica os checkbox marcado e retorna uma lista com os valores
function listaValuesCheckboxMarcado() {
    var array_values = [];

    $('input[type=checkbox]').each(function () {
        if ($(this).is(':checked')) {
            var nome_campo = $(this).attr('name');
            criarHidden(nome_campo, $(this).val());//cria o campo hiddem e coloca o valor que está marcado no checkbox

            //array_values.push($(this).val());
        }
    });

    var arrayValues = array_values.join(',');

    return arrayValues;
}
//#endregion 

//#region sweet alert para confirmar se quer deletar ou não
function botaoConfirmarDelete(url, urlRedirecionamento) {

    swal({
        title: "Deletar",
        text: "Voc\u00ea tem certeza que deseja deletar?",
        type: "warning",
        showCancelButton: true,
        closeOnConfirm: false,
        showLoaderOnConfirm: true,
    }, function () {
        ajaxSubmitRetorno(url, function (returnValue) {

            if (returnValue == true) {
                swal(
                    {
                        title: "Ok!",
                        text: "Foi deletado com sucesso!",
                        type: "success",
                    },
                    function () {
                        window.location.href = dominioInicial() + urlRedirecionamento;
                    }
                );
            } else {
                swal(
                    {
                        title: "Erro!",
                        text: "N\u00e3o pode ser deletado. Tente mais tarde!",
                        type: "error",
                    }
                );
            }

        })
    });
};
//#endregion 

//#region funcao genérica para dar swal de campo obrigatório
function alertCampoObrigatorio(campo, mensagemDiferenciada) {

    if (mensagemDiferenciada == 'email') {
        swal("Aten\u00e7\u00e3o !", "Digite um endereço de e-mail v\u00e1lido.", "warning");
    } else if (mensagemDiferenciada == 'senha') {
        swal("Aten\u00e7\u00e3o !", "Senha muito insegura, digite uma senha maior.", "warning");
    } else {
        swal("Aten\u00e7\u00e3o !", "Campos obrigat\u00f3rios n\u00e3o foram preenchidos.", "warning");
    }

    jQuery("#campoObritagorioAtual").val(jQuery(campo).attr('id'));
    return false;
}
//#endregion

//#region funcao genérica para dar swal de campo obrigatório simples
function alertCampoObrigatorioComValidacaoSimples(vetorCampos, mensagemDiferenciada) {

    for (i = 0; i < vetorCampos.length; i++) {
        if (jQuery('#' + vetorCampos[i]).val() == "") {

            if (mensagemDiferenciada == 'email') {
                swal("Aten\u00e7\u00e3o !", "Digite um endereço de e-mail v\u00e1lido.", "warning");
            } else if (mensagemDiferenciada == 'senha') {
                swal("Aten\u00e7\u00e3o !", "Senha muito insegura, digite uma senha maior.", "warning");
            } else {

                $("#" + vetorCampos[i]).css({ "border": "1px solid #F00" });

                swal("Aten\u00e7\u00e3o !", "Campos obrigat\u00f3rios n\u00e3o foram preenchidos.", "warning");

            }


            //jQuery("#campoObritagorioAtual").val(jQuery('#' + vetorCampos[i]).attr('id'));

        } else {

            $("#" + vetorCampos[i]).css({ "border": "1px solid #d7dce5" });

        }

    }

}
//#endregion

//#region funcao genérica para colocar m´scara de valor. Modo de uso:  <input onkeyup="mascaraMoney(this, event, '###.###.###,##', true)" keydown="mascaraMoney(this,event,'###.###.###,##',true)">
function mascaraMoney(w, e, m, r, a) {
    console.log(w);
    // Cancela se o evento for Backspace
    if (!e) var e = window.event
    if (e.keyCode) code = e.keyCode;
    else if (e.which) code = e.which;

    // Variáveis da função
    var txt = (!r) ? w.value.replace(/[^\d]+/gi, '') : w.value.replace(/[^\d]+/gi, '').reverse();
    var mask = (!r) ? m : m.reverse();
    var pre = (a) ? a.pre : "";
    var pos = (a) ? a.pos : "";
    var ret = "";

    if (code == 9 || code == 8 || txt.length == mask.replace(/[^#]+/g, '').length) return false;
    // Loop na mÃ¡scara para aplicar os caracteres
    for (var x = 0, y = 0, z = mask.length; x < z && y < txt.length;) {
        if (mask.charAt(x) != '#') {
            ret += mask.charAt(x); x++;
        }
        else {
            ret += txt.charAt(y); y++; x++;
        }
    }
    // Retorno da funÃ§Ã£o
    ret = (!r) ? ret : ret.reverse()
    w.value = pre + ret + pos;
}
// Novo mÃ©todo para o objeto 'String'
String.prototype.reverse = function () {
    return this.split('').reverse().join('');
};
//#endregion


//#region Função para formatar valor em número real (R$) - money // mode de uso: exibirValor(valorFinalAposta.toFixed(2))
function exibirValor(valor) {

    tam = valor.length;
    if (tam <= 2) {
        return valor;
    }
    if ((tam > 2) && (tam <= 6)) {
        return valor.replace(".", ",");
    }
    if ((tam > 6) && (tam <= 9)) {
        return valor.substr(0, tam - 6) + '.' + valor.substr(tam - 6, 3) + ',' + valor.substr(tam - 2, tam);
    }
    if ((tam > 9) && (tam <= 12)) {
        return valor.substr(0, tam - 9) + '.' + valor.substr(tam - 9, 3) + '.' + valor.substr(tam - 6, 3) + ',' + valor.substr(tam - 2, tam);
    }
}
//#endregion


function ajaxSubmitAssincrono(urlx) {
    $.ajax({
        cache: false,
        type: 'POST',
        url: urlx,
        contentType: "json",
        async: true,
        success: function (data) {
            return;
        },
        error: function (jqXHR, exception) {
            if (jqXHR.status === 0) {
                alert('Not connect.\n Verify Network.');
                return;
            } else if (jqXHR.status == 404) {
                alert('Requested page not found. [404]');
                return;
            } else if (jqXHR.status == 500) {
                alert('Internal Server Error [500].');
                return;
            } else if (exception === 'parsererror') {
                alert('Requested JSON parse failed.');
                return;
            } else if (exception === 'timeout') {
                alert('Time out error.');
                return;
            } else if (exception === 'abort') {
                alert('Ajax request aborted.');
                return;
            } else {
                alert('Uncaught Error.\n' + jqXHR.responseText);
                return;
            }

        }
    });
}

function preencheOptionJson(urlx, idOption, nodeValue, nodeNome) {
    var ajaxRetorno;
    ajaxSubmitRetorno(urlx, function (returnValue) {
        ajaxRetorno = returnValue;

    });
    var options = "";
    var value = nodeValue;
    var nome = nodeNome;
    var id = idOption;
    var obj = $.parseJSON(ajaxRetorno);
    for (var it = 0; it < obj.length; it++) {
        options += '<option value="' + obj[it].value + '">' + obj[it].nome + '</option>';
    }
    return options;

}

function mostraEscondeCampos(idForm, campos, acao) {
    if (acao == 0) {
        $('#' + idForm).find(campos).each(function (i, field) {
            document.getElementById(field.id).style.display = 'none';

        });
    } else {
        $('#' + idForm).find(campos).each(function (i, field) {
            document.getElementById(field.id).style.display = 'block';

        });

    }
}

function trataData(modelo, data) {

    var d = new Date(data);
    var dataTratada;
    if (!!d.valueOf()) { //valida data
        ano = d.getFullYear();
        dia = (d.getMonth() + 1);//aqui eu colo +1 no mês por que por algum motivo ele sempre tras o mes - 1
        mes = d.getDate() + 1;
        dataTratada = mes + "/" + dia + "/" + ano
        return dataTratada;

    } else {
        return "N\u00e3o informado";
    }

}


//#transforma a data para padrão brasil
function trataDataSimples(modelo, data) {

    var d = new Date(data),
        mes = '' + (d.getMonth() + 1),
        dia = '' + d.getDate(),
        ano = d.getFullYear();

    if (mes.length < 2) mes = '0' + mes;
    if (dia.length < 2) dia = '0' + dia;

    return [dia, mes, ano].join('/'); // "join" é o caracter para separar a formatação da data, neste caso, a barra (/)

}
//#endregion

function valorUsuarioSessao(jsonObj) {
    var retorno;
    for (a = 0; a < jsonObj.length; a++) {
        retorno = jsonObj[a].COD_USUARIO;
    }
    return retorno;
}


function contaCamposGeral(idForm, campos) {
    var num = 0;
    $('#' + idForm).find(campos).each(function (i, field) {
        if (jQuery(this).attr("name") != "" && typeof jQuery(this).attr("name") != 'undefined') { //aqui verifica se o campo tem name se não tiver name ele nao conta 
            num++;
        }

    });
    return num;

}

function rolagem(obj) {
    jQuery('html, body').animate({
        scrollTop: jQuery(obj).offset().top - 100
    }, 1000);
}

//#region ajax envio de imagem

function ajaxParaUpload(urlEnvio, parametros, retornoPost) {

    //#region ajax envio da imagem
    $.ajax({
        url: urlEnvio,
        type: "POST",
        datype: "html",
        data: new FormData(parametros),
        async: false,
        cache: false,
        contentType: false,
        processData: false,
        success: retornoPost,
        error: function (jqXHR, exception) {
            if (jqXHR.status === 0) {
                swal("Erro!", 'Not connect.\n Verify Network.', "error");
                return;
            } else if (jqXHR.status == 404) {
                swal("Erro!", 'Requested page not found. [404]', "error");
                return;
            } else if (jqXHR.status == 500) {
                swal("Erro!", 'Internal Server Error [500].', "error");
                return;
            } else if (exception === 'parsererror') {
                swal("Erro!", 'Requested JSON parse failed.', "error");
                return;
            } else if (exception === 'timeout') {
                swal("Erro!", 'Time out error.', "error");
                return;
            } else if (exception === 'abort') {
                swal("Erro!", 'Ajax request aborted.', "error");
                return;
            } else {
                swal("Erro!", 'Uncaught Error.\n' + jqXHR.responseText, "error");
                return;
            }

        }
    });
    //#endregion


}

//#endregion

//#region criar campo hideden
function criarHidden(nomeCampo, valor) {

    $('form').append('<input type="hidden" name="' + nomeCampo + '" id="' + nomeCampo + '" value="' + valor + '" />');

}
//#endregion

//#region marca checkbox com checado
function marcaCheckBoxComChecado(idsCheckBox) {
    var array_values = [];

    $('input[type=checkbox]').each(function () {
        if ($(this).is(':checked')) {
            array_values.push($(this).val());
        }
    });

    var arrayValues = array_values.join(',');

    return arrayValues;
}

//#endregion

//#region preenche os campos  automaticamente para editar 
function montaCamposEditar(itemFiltrado, idParaForeach) {

    var vetorPropriedadesDoObjeto = Object.keys(itemFiltrado);

    try {
        jQuery(idParaForeach).each(function (index) { //percorre a div para pegar os valores dentro dela automaticamente para preencher o objeto de pedido, com as informações do pedido

            for (i = 0; i < vetorPropriedadesDoObjeto.length; i++) {

                var nomeDoCampoDoFormulario = jQuery(this).find('input,textarea,select,input:file,hidden,date').attr('id');//pega o nome dos campos do formulario

                var nomeDoCampoDoFormularioSemTabela = nomeDoCampoDoFormulario.substring(nomeDoCampoDoFormulario.indexOf("_") + 1);//pega os valores do json e retira o nome da tabela da frente 
                var nomeDoCampoDoFormularioSemPonto = nomeDoCampoDoFormulario.substring(nomeDoCampoDoFormulario.indexOf(".") + 1);//pega os valores do json e retira o nome da tabela da frente 

                if (vetorPropriedadesDoObjeto[i] === nomeDoCampoDoFormularioSemTabela || vetorPropriedadesDoObjeto[i] === nomeDoCampoDoFormularioSemPonto) {

                    if ($('#' + nomeDoCampoDoFormulario).length > 0) {//aqui é pra verificar se nó existe

                        if ($('#' + nomeDoCampoDoFormulario).get(0).nodeName == 'SELECT') {//condicional pra quando for um select option o campo
                            $('#' + nomeDoCampoDoFormulario).val(itemFiltrado[nomeDoCampoDoFormularioSemPonto]).change();

                        } else {
                            jQuery('#' + nomeDoCampoDoFormulario).val(itemFiltrado[nomeDoCampoDoFormularioSemTabela]); //coloca o valor dentro do campo

                        }
                        delete vetorPropriedadesDoObjeto[i];

                    }

                }
                else {

                    //essa variavel nomeDoCampoDiferencial eu coloquei pra adapatar pra oq ja tinha, por que pode vim do banco colunas repetidas entao no procedimento eu coloco a nomemclatura tabela___coluna
                    var nomeDoCampoDiferencial = typeof vetorPropriedadesDoObjeto[i] != "undefined" ? vetorPropriedadesDoObjeto[i].replace("___", "_") : false;

                    if (nomeDoCampoDiferencial == nomeDoCampoDoFormulario) {//aqui eu verifico se existe esse campo com esse nome se existir eu preencho com o valor que está no array

                        if ($('#' + nomeDoCampoDoFormulario).length > 0) {

                            if ($('#' + nomeDoCampoDoFormulario).get(0).nodeName == 'SELECT') {//condicional pra quando for um select option o campo

                                $('#' + nomeDoCampoDoFormulario).val(itemFiltrado[vetorPropriedadesDoObjeto[i]]).change();

                            } else {

                                jQuery('#' + nomeDoCampoDoFormulario).val(itemFiltrado[vetorPropriedadesDoObjeto[i]]).change(); //esconde o botão de salvar
                            }

                            delete vetorPropriedadesDoObjeto[i];
                        }

                    }

                }
            }


        })
    } catch (e) {
        console.log(e);
        var x = 0;
        var f = 56;
        //swal("Erro!", "Erro interno, favor entrar em contato com o suporte", "error");//("Erro!", data, "error");
    }


}
//#endregion

//#region trata os valores que vem nulos na listagem que vem do controller, coloca algum texto para não ficar null
function trataValorNull(objValores) {
    for (var a = 0; a < objValores.length; a++) {

        Object.keys(objValores[a]).map(function (objectKey, index) {
            objValores[a][objectKey] == null || typeof objValores[a][objectKey] == "undefined" ? (objValores[a][objectKey] = 'N\u00e3o informado') : objValores[0][objectKey];
        });
    }

    return objValores;

}
//#endregion

//#region verifica os checkbox marcado e criar os hideens com valores e o nome do campo
function criarHiddeParaCheckBox(form) {
    var array_values = [];
    var i = 0;
    //$('#myform')[0].reset();
    $('input[type=checkbox]').each(function () {
        if ($(this).is(':checked')) {
            var nome_campos = $(this).attr('name');
            var valor_campos = $(this).val();
            //criarHidden("tb_lojista_has_tb_regioes_que_atua-tb_regioes_que_atua_cod_regioes_entrega", 1);//cria o campo hiddem pra o filtro do update
            $('#' + form).append('<input type="hidden" name="' + nome_campos + '" id="' + nome_campos + '" value="' + valor_campos + '" />');

            //criarHidden(nome_campo, $(this).val());//cria o campo hiddem e coloca o valor que está marcado no checkbox
            //return true;
            i++;
            //array_values.push($(this).val());
        }
    });

    //var arrayValues = array_values.join(',');

    //return arrayValues;
}
//#endregion 

//#region verifica se existe o valor no objeto
function ChecaValorEmObjeto(obj, value) {
    for (var id in obj) {
        if (obj[id] == value) {
            return true;
        }
    }
    return false;
}
//#endregion


//#region verifica se os campos foram preenchidos, exemplo de parametro ChecaValorEmObjeto(#formCadUsuario input, select, radio,)
function verificaCampo(formCampos, objExcessoes) {
    var cont = 0;

    var contLabel = 0;
    //var x = Array();
    //jQuery('.control-label').each(function () {

    //    x.push(jQuery(this).text());
    //});

    //jQuery('#formCadLojista .control-label').each(function () {
    //    jQuery(this).text();
    //});

    jQuery(formCampos).each(function (e) {

        //x;

        var excessoes = ChecaValorEmObjeto(objExcessoes, $(this).attr("name"));//verifica as excessoes, isso é pra não validar campos não obrigatrios

        var tipoDoCampo = (typeof $(this).attr("name") == "undefined") ? false : $(this).attr("type");

        if (tipoDoCampo && tipoDoCampo != "submit" && tipoDoCampo != "button") {//se o campo for submit ou button ou undefined não entra pra fazer as validações

            if ($(this).val() == "" && $(this).is(':visible')) {//verifica se o campo está vazio

                if (typeof objExcessoes != "undefined") {

                    if ((typeof objExcessoes == "undefined") ? true : excessoes === false ? false : true) {//verifica se o objeto excessoes está preenchido, se tiver preenchido ele verifica quais os campos que não são obrigatorio
                        $("#" + $(this).attr("name")).css({ "border": "1px solid #F00" });
                        cont++;
                    } else {
                        $("#" + $(this).attr("name")).css({ "border": "1px solid #d7dce5" });
                    }

                } else {

                    var labels = document.getElementsByTagName('label');
                    var textoDoLabel = (typeof labels[contLabel] == "undefined") ? false : labels[contLabel].textContent;

                    if (textoDoLabel.charAt(textoDoLabel.length - 1) == "*") {//verifica se o campo é obrigatorio, verificando se o ultimo caracter é um *, se for então é obrigatorio

                        if ((typeof objExcessoes == "undefined") ? true : excessoes === false ? true : false) {//verifica se o objeto excessoes está preenchido, se tiver preenchido ele verifica quais os campos que não são obrigatorio
                            $("#" + $(this).attr("name")).css({ "border": "1px solid #F00" });
                            cont++;
                        } else {
                            $("#" + $(this).attr("name")).css({ "border": "1px solid #d7dce5" });
                        }

                    } else {
                        $("#" + $(this).attr("name")).css({ "border": "1px solid #d7dce5" });
                    }
                }

            } else {
                $("#" + $(this).attr("name")).css({ "border": "1px solid #d7dce5" });
            }
            contLabel++;
        }

        //}else if (typeof objExcessoes == "undefined" ? true : excessoes === false ? false : true) {
        //    $(this).css({ "border": "1px solid #F00" });
        //    cont++;
        //}else {
        //    $(this).css({ "border": "1px solid #d7dce5" });
        //}


    });
    if (cont > 0) {
        return false;
    } else {
        return true;

    }

}
//#endregion


//#region verifica os checkbox marcado e retorna uma lista com os valores no vetor
function listaValuesCheckboxMarcadoVetor(id_elemento) {

    var array_values = [];

    if (id_elemento) {
        $('#' + id_elemento + 'input:checked').each(function () {
            if ($(this).is(':checked')) {
                array_values.push($(this).val());
            }
        });

    } else {
        $('input[type=checkbox]').each(function () {
            if ($(this).is(':checked')) {
                array_values.push($(this).val());
            }
        });
    }

    var arrayValues = array_values.join(',');

    return arrayValues;
}
//#endregion 

//#region Transformar o número para conseguir fazer o cálculo, pois o jquery nao entende padrão numérico brasileiro (1.000,00) ~> (1000.00)
function transformNumPadraoUS(numero) {

    try {

        if (numero !== undefined) {
            numero = numero.replace(',', '');
            numero = numero.replace('.', '');
            numero = parseFloat(numero);
            numero = numero / 100;
            return numero;
        }
    } catch (e) {
        console.log(e);
        inseriLog(JSON.stringify(e), "erro");//inseri log no sistema, esa função está no arquivo /util/funcoes.js
        return numero;
    }
}
//#endregion

//#region verifica os checkbox marcado e retorna uma lista com os valores
function listaValuesCheckboxMarcadoOrigi() {
    var array_values = [];

    $('input[type=checkbox]').each(function () {
        if ($(this).is(':checked')) {
            array_values.push($(this).val());
        }
    });

    var arrayValues = array_values.join(',');

    return arrayValues;
}
//#endregion 

//#region função para formatar valor real dinheiro 

function formatReal(int) {

    //var int = parseInt(int.replace(/[\D]+/g, ''));

    var tmp = int + '';
    tmp = tmp.replace(/([0-9]{2})$/g, ",$1");
    if (tmp.length > 6)
        tmp = tmp.replace(/([0-9]{3}),([0-9]{2}$)/g, ".$1,$2");

    return tmp;
}

//#endregion

//#region função para salvar no banco logs do aplicativo
function inseriLog(msg_log, tipo_log, numero_da_linha) {

    //console.log(device.platform);
    //console.log(device.manufacturer);
    //console.log(device.version);


    var dadosCliente = JSON.parse(localStorage.getItem('login'));

    var cod_cliente;

    if (dadosCliente) {
        cod_cliente = dadosCliente[0].cod_cliente
    } else {
        cod_cliente = "";
    }

    var url_log = "Log/Inserir";

    var objLog = {};

    objLog.pdata = {
        dataForm:
            + "tb_log-texto=" + msg_log
            + "&tb_log-tipo_do_log=" + tipo_log
            + "& tb_log-nome_da_pagina=" + window.location.href
            + "&tb_log-tb_cliente_cod_cliente=" + cod_cliente
            + "&tb_log-numero_da_linha=" + numero_da_linha

    };// monta o objeto que são os parametros pra passar pro controller
    try {
        ajaxSubmitRetornoPost(url_log, objLog, "POST", function (returnValue) {
            console.log(returnValue);

        });
    } catch (e) {
        console.log(e);

    }

}
//#endregion

//#region pega os valores marcados do select option multi checkbox e retorna uma lista

function multiselectOption(comando) {

    try {

        var selected = $(comando);
        var array_values = [];

        selected.each(function () {
            array_values.push($(this).val());

        });

        return array_values.join(',');

    } catch (e) {
        console.log(e);
        return false;
    }

}

//#endregion

//#region cria select option baseado no parametro

function criarSelectOption(objArg) {

    try {

        var value_do_selectoption = objArg.value_do_selectoption;
        var text_do_selectoption = objArg.text_do_selectoption;

        var options4 = $(objArg.id_que_vai_renderizar);//essas \\ é para não da problema porque o id tem . no nome

        for (var it = 0; it < objArg.interacao_for.length; it++) {

            options4.append($("<option />").val(objArg.interacao_for[it][value_do_selectoption]).text(objArg.interacao_for[it][text_do_selectoption]));

        }

    } catch (e) {
        console.log(e);
        return false;
    }

}

//#endregion










