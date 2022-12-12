
//#region inicio variaveis globais
var jsonUsuario;
//#endregion

//#region verifica se tem alguma coisa na sessão de usuario vendedor, se tiver monta o menu para usuario vendendor se não monta o menu do usuario fornecedor

if (localStorage.getItem("sessaoUsuario") !== null) {

    jsonUsuario = JSON.parse(localStorage.getItem('sessaoUsuario')); //coloca o json do usuario em uma variavel global

    for (var i = 0; i < jsonUsuario.length; i++) {//lista json

        if (jsonUsuario[i].menu == "sim") {//se for menu e não submenu

            jQuery('#mainMenu').append('\
                <li id="menu'+ jsonUsuario[i].id_menu + '" class="submenu">\
                    <a class="waves-effect waves-light" href="#piluku_utility">\
                        <i class="'+ jsonUsuario[i].icone + '"></i>\
                        <span class="text">'+ jsonUsuario[i].sigla + '</span>\
                        <i class="chevron ti-angle-right"></i>\
                    </a>\
                </li>\
            ');

        } else {//se for submenu
            jQuery('#menu' + jsonUsuario[i].id_menu).append('\
                <ul class="list-unstyled" id="submenu_'+ jsonUsuario[i].id_menu + '"></ul>\
            ');
            jQuery('#submenu_' + jsonUsuario[i].id_menu).append('\
                <li><a href="#" onclick="redireciona(\''+ jsonUsuario[i].url + '\');">' + jsonUsuario[i].sigla + '</a></li>\
            ');
        }

    }

}

//#endregion

