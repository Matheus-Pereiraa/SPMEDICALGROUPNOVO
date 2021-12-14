import '../../assets/css/Login.css'
import { parseJwt } from '../../Services/auth';


import { Component } from "react";
// import axios from 'axios';
import api from '../../Services/api';
import Header from '../../Components/Header/Header';

export default class Login extends Component {
    constructor(props) {
        super(props)
        this.state = {
            email: 'matheus@outlook.com',
            senha: 'Lili123321',
            erroMensagem: '',
            isLoading: false
        };
    };

    efetuaLogin = (event) => {
        this.setState({ erroMensagem: " ", isLoading: true })
        event.preventDefault();
        api.post('/login', {
            email: this.state.email,
            senha: this.state.senha
        })

            .then(resposta => {
                if (resposta.status === 200) {
                    console.log(resposta.data.token)
                    localStorage.setItem('usuario-token', resposta.data.token)
                    this.setState({ isLoading: false });
                    
                   
                    
                    switch (parseJwt().role) {
                        case '1':
                            // verifica se o usuário logado é paciente
                            this.props.history.push('/listarPaciente');                          
                            break;
                            case '2':
                            // verifica se o usuário logado é  administrador
                            this.props.history.push('/listarAdm');
                            break;
                            case '3':
                            // verifica se o usuário logado é médico
                            this.props.history.push('/listarMedico');
                            break;
                        default:
                            this.props.history.push('/');
                            break;
                    }
                }
            })

            .catch(() => {
                this.setState({ isLoading: false });
                this.setState({ erroMensagem: "E-mail ou senha inválidos!" })
            })
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value })
    }

    render() {
        return (
            <div>
                <Header/>
                <main className="main_login">
                    <div className="cor_login">
                        <div className="container container_consultas">
                            <h1 className="h1_login">Login</h1>
                            <div className="box_login fundo">
                                <form className="box_info-login" onSubmit={this.efetuaLogin}>
                                    <input
                                        type="text"
                                        name="email"
                                        value={this.state.email}
                                        onChange={this.atualizaStateCampo}
                                        placeholder="Email"
                                    />
                                    <input
                                        type="password"
                                        name="senha"
                                        value={this.state.senha}
                                        onChange={this.atualizaStateCampo}
                                        placeholder="Senha" />
                                    {
                                            // Caso seja true, renderiza o botão desabilitado com o texto 'Loading...'
                                            this.state.isLoading === true &&
                                            <button type="submit" disabled >
                                                Loading...
                                            </button>
                                        }

                                        {
                                            // Caso seja false, renderiza o botão habilitado com o texto 'Login'
                                            this.state.isLoading === false &&
                                            <button 
                                                type="submit"
                                                disabled={ this.state.email === '' || this.state.senha === '' ? 'none' : '' }>
                                                Login
                                            </button>
                                        }
                                </form>
                                <p style={{ color: 'red', fontSize: '25px' }}>{this.state.erroMensagem}</p>
                            </div>
                        </div>
                    </div>
                </main>
            </div>
        )
    }
}