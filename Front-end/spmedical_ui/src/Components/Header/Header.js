import { parseJwt, usuarioAutenticado } from '../../Services/auth.js';

import React, { Component } from "react";
import { Link } from 'react-router-dom';

export default class Header extends Component {

    toggleMenu = () => {
        const nav = document.getElementById('nav');
        nav.classList.toggle('active');
    }

    listar = () => {

        console.log("logou")


        if (parseJwt() != null) {



            switch (parseJwt().role) {
                case '1':
                    // verifica se o usuário logado é do tipo paciente
                    window.location.href = "/listarPaciente"
                    console.log('estou logado: ' + usuarioAutenticado())

                    break;
                case '2':
                    // verifica se o usuário logado é do tipo administrador
                    window.location.href = "/listarAdm"
                    console.log('estou logado: ' + usuarioAutenticado())

                    break;
                case '3':
                    // verifica se o usuário logado é do tipo médico
                    window.location.href = "/listarMedico"
                    console.log('estou logado: ' + usuarioAutenticado())
                    break;
                default:
                    window.location.href = "/login"
                    console.log('estou logado: ' + usuarioAutenticado())
                    break;
            }

        } else {
            alert("Usuario nao está logado.")
        }


    }

    render() {

        return (
            <header>
                <div className="container container_header">
                    <button id="btnMenu" onClick={() => this.toggleMenu()} >
                    </button>
                    <nav id="nav">
                        <ul id="menu">
                            <Link to="/">Home</Link>
                            <Link to="/cadastrar">Cadastrar</Link>
                            <button onClick={() => this.listar()}>Listar</button>

                        </ul>

                    </nav>
                    <span></span>
                    <Link to="/login" className="login">{this.props.Login}</Link>
                </div>
            </header>

        )
    }
}