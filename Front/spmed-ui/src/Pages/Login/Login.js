import { Component } from "react";
import axios from "axios";



 export default class Login extends Component{
    constructor(props){
        super(props);
        this.state = {
            Email : '',
            Senha : '',
            erroMensagem : '',
            isLoading : false
        };
    };

    efetualogin = (event) => {
        event.preventDefault()

        this.state({erroMensagem : '', isLoading : true })
        
        axios.post('htttp://localhost:5000/api/Login', {
            Email : this.state.Email, 
            Senha : this.state.Senha
        })

        .then(resposta => {
            if (resposta.status === 200){
                console.log('Meu Token é' + resposta.data.token);
                localStorage.setItem('usuario-token', resposta.data.token)
                this.setState({isLoading : false})
            }
            

            
        })
        .catch(() => {
            this.setState({ erroMensagem : 'E-mail e/ou senha inválidos' })
        })
    }

    atualizaStateCampo  = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value })
    }


    render(){
        return(
            <div>
                <main>
                    <section>
                        
                        <h1> LOGIN <br/> faça o login para acessar sua conta </h1>

                        <form onSubmit={this.efetualogin}>
                        <input 
                            type="text"
                            name="Email"
                            value={this.state.Email}
                            onchange={this.atualizaStateCampo}
                            placeholder="username"
                            />

                            <input 
                            type="password"
                            name="Senha"
                            value={this.state.Senha}
                            onchange={this.atualizaStateCampo}
                            placeholder="Escreva sua senha"
                            />
                           
                            <p style={{color : 'red'}}>{this.state.erroMensagem}</p>

                           <button type="submit">
                               Login
                           </button>

                        </form>
                    </section>
                </main>
            </div>
        )
    }

};



