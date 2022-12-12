
function ajaxSubmit(urlx, idFormulario) {

    var formulario = $('#' + idFormulario).serialize();
    var paramCont = "#" + idFormulario + " " + "input, select, radio"
    var qtdCampos = contaCamposGeral(idFormulario, 'input, textarea, checkbox, radio, select');
    if (verificaCampo(paramCont)) {

        var urlEnvio = urlx + formulario + "&contadorCampos=" + (qtdCampos - 1);
        //var jqxhr = $.get("http://192.168.2.115:13481/controllers/control_login/login_fornecedor.php", function (status, data) {
        //    alert(data + "  " + status);
        //})
        $.ajax({
            cache: false,
            type: 'POST',
            url: urlEnvio,
            contentType: "json",
            async: false,
            success: function (data) {
                
                window.location.href = localStorage.getItem("dominioInicial") + 'view/inicial/caixa_de_entrada.php';
            },
            error: function (jqXHR, exception) {
                if (jqXHR.status === 0) {
                    alert('Not connect.\n Verify Network.');
                } else if (jqXHR.status == 404) {
                    alert('Requested page not found. [404]');
                } else if (jqXHR.status == 500) {
                    alert('Internal Server Error [500].');
                } else if (exception === 'parsererror') {
                    alert('Requested JSON parse failed.');
                } else if (exception === 'timeout') {
                    alert('Time out error.');
                } else if (exception === 'abort') {
                    alert('Ajax request aborted.');
                } else {
                    alert('Uncaught Error.\n' + jqXHR.responseText);
                }

            }
        });
    }

    //if (verificaCampo("#formLogin input, select, radio")) {
    //    var httpReq = null;
    //    httpReq = new plugin.HttpRequest();
    //    var formulario = $("#formLogin").serialize();
    //    var qtdCampos = contaCamposGeral($(this).closest("form").attr('id'), 'input, textarea, checkbox, radio, select');
    //    var urlEnvio = "http://192.168.2.115:4125/controllers/control_login/login.php?" + formulario + "&contadorCampos=" + (qtdCampos - 1);

    //    httpReq.get(urlEnvio, function (status, data) {
    //        if (data == "false") {
    //            ActivityIndicator.hide();
    //            navigator.notification.alert("Usu\u00e1rio não encontrado!");

    //        } else {
    //            var obj = $.parseJSON(data);
    //            window.localStorage.setItem('jsonUser', data);
    //            var idParam = getUrlVars()["idAnuncio"];
    //            if ((idParam != "") && (typeof idParam !== "undefined") && idParam == "cadEvento") {
    //                window.location.href = "cadastro_evento.html";
    //            }
    //            else if ((idParam != "") && (typeof idParam !== "undefined")) {
    //                window.location.href = "proposta.html?idAnuncio=" + idParam;
    //            } else if (typeof data == 'undefined') {
    //                navigator.notification.alert("Erro na busca dos dados!");
    //                ActivityIndicator.hide();
    //            } else {
    //                window.location.href = "inicial.html";
    //            }
    //            ActivityIndicator.hide();
    //        }

    //    });

    //    return false;
    //} else {
    //    navigator.notification.alert("Preencha os campos marcados em vermelho!");
    //    ActivityIndicator.hide();
    //    return false;
    //}



    //if (event != null) {
    //    event.preventDefault();
    //}
    //var divDestino = "#" + destino;

    //$.ajax({
    //    cache: false,
    //    type: tipo,
    //    url: url,
    //    data: dados,
    //    success: function (partial) {
    //        if (partial != "") {
    //            $(divDestino).html(partial);
    //        }
    //        else {
    //            location.reload();
    //        }
    //    },
    //    error: function (jqXHR, textStatus, errorThrown) {
    //        errorNotification(jqXHR, textStatus, errorThrown);
    //    }
    //});
}

/*
jQuery(function(){
    var formObject = $('#formParametros');
    formObject.data('original_serialized_form', formObject.serialize());

    $(':submit').click(function() {
        window.onbeforeunload = null;
    });

    window.onbeforeunload = function() {
        if (formObject.data('original_serialized_form') !== formObject.serialize()) {
            return "As mudanças deste formulário não foram salvas. Saindo desta página, todas as mudanças serão perdidas.";
        }
    };
});
*/