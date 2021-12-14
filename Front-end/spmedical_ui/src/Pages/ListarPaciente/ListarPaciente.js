import '../../assets/css/ListarMedico.css'
import Header from '../../Components/Header/Header';


import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import api from '../../Services/api';


export default function ListarPaciente() {
    var [erroMensagem = ''] = useState([])

    const [listaConsultasPaciente, setListaConsultasPaciente] = useState([]);
    // const [ isLoading, setIsLoading ] = useState( false );

    function buscarConsultasPaciente() {


        api.get('Consulta/minhas', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-token')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaConsultasPaciente(resposta.data)
                }
            })

            // caso ocorra algum erro, exibe no console do navegador este erro
            .catch(erro => console.log(erro));
    };

    function listarConsulta() {
        if (listaConsultasPaciente.length === 0) {
           erroMensagem = 'Você não possui consulta cadastrada'
            
            
        } else  {
            
         
            return(
                listaConsultasPaciente.map((Consulta) => {
                    return (
                        <div className="box_consulta" key={Consulta.idConsulta}>
                            <h2 className="h2_consulta">Consulta {Consulta.idConsulta}</h2>
                            <div className="box_info">
                                <p>Data</p>
                                <span>{Intl.DateTimeFormat("pt-BR", {
                                    year: 'numeric', month: 'short', day: 'numeric',
                                    hour: 'numeric', minute: 'numeric',
                                    hour12: true
                                }).format(new Date(Consulta.dataConsulta))}</span>
                                <p>Descrição</p>
                                <span>{Consulta.descricao}</span>
                                <p>Situação</p>
                                <span>{Consulta.idSituacaoNavigation.situacao1}</span>
                            </div>
                            <h2 className="h2_consulta">Médico</h2>
                            <div className="box_info">
                                <p>Nome</p>
                                <span>{Consulta.idMedicoNavigation.nomeMed}</span>
                                <p>CRM</p>
                                <span>{Consulta.idMedicoNavigation.crm}</span>
                                <p>Especialidade</p>
                                <span>{Consulta.idMedicoNavigation.idEspecialidadeNavigation.tituloEspecialidade}</span>
                            </div>
                        </div>
                    )
                })
            )
            

        }

    }

    // estrutura do Hook useEffect
    // useEffect( efeito, causa )
    // useEffect( { o que vai ser feito }, { o que será escutado } )
    // dessa forma, 
    useEffect(buscarConsultasPaciente, []);

    return (
        <div>
            <Header />
            <main className="main_listar">
                <div className="container container_consultas">
                    <h1>Consultas</h1>
                    {
                        listarConsulta()
                    }
                    <p style={{ color: 'red', fontSize: '25px', padding: '10px'}}>{erroMensagem}</p>
                    <Link to='/'><button className="btn_home">Voltar</button></Link>

                </div>
            </main>

            <footer>
                <div className="container container_footer">
                    <span className="span_footer">
                        ©2020 Cia. da Consulta - Todos os direitos reservados
                    </span>
                    <span className="span_footer">
                        Os médicos da Central de Consultas são especialistas ou estão em conclusão de sua pós-graduação.
                    </span>
                </div>
            </footer>

        </div>

    )
}