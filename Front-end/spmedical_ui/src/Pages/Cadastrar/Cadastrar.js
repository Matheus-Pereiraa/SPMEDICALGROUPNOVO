import Header from '../../Components/Header/Header';



import { useState, useEffect } from "react";
import api from '../../Services/api';


export default function Cadastrar () {
    const [listaPacientes, setListaPacientes] = useState([]);
    const [listaMedicos, setListaMedicos] = useState([]);


    const [idPaciente, setIdPaciente] = useState(0);
    const [idMedico, setIdMedico] = useState(0);
    const [idSituacao, setIdSituacao] = useState(0);
    const [dataConsulta, setDataConsulta] = useState(new Date());
    const [descricao, setDescricao] = useState("");



    function buscarPacientes() {
        api.get('/UsariosPacientes', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-token')
            }
        }).then(resposta => {
            if (resposta.status === 200) {
                setListaPacientes(resposta.data);
                console.log(resposta.data)
            }
        }).catch((erro) => console.log(erro))
    }

    useEffect(buscarPacientes, []);

    function buscarMedico() {
        api.get('/Medico', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-token')
            }
        }).then(resposta => {
            if (resposta.status === 200) {
                setListaMedicos(resposta.data);
                console.log(resposta.data)
            }
        }).catch((erro) => console.log(erro))
    }

    useEffect(buscarMedico, [])

    
    function cadastrarConsulta(evento) {
        evento.preventDefault();
        api.post('/Consulta', {
            idMedico: idMedico,
            idPaciente: idPaciente,
            idSituacao: idSituacao,
            dataConsulta: dataConsulta,
            descricao: descricao
        }, {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-token'),
            },
        })
            .then(resposta => {
                if (resposta.status === 201) {
                    console.log('Consulta Cadastrada')
                    setIdPaciente(0);
                    setIdMedico(0);
                    setIdSituacao(0);
                    setDataConsulta(new Date());
                    setDescricao("");
                    window.location.href = "/listarAdm"

                }
            })
            .catch((erro) => {
                if (erro.toJSON().status === 401) {
                    window.location.href = "/login"
                }
                else console.log(erro)
            })
    }
    return (
        <div>
            <Header />
            <main className="main_cadastro" >
                <div className="container container_consultas">
                    <h1>Cadastrar Consulta</h1>
                    <div className="box_consulta-cadastro">
                        <form className="box_info-cadastro" onSubmit={cadastrarConsulta}>
                            <select name="paciente" id="paciente" defaultValue={idPaciente} value={idPaciente} onChange={(campo) => setIdPaciente(campo.target.value)} className="selects" required>
                                <option value="0" selected disabled> Selecione o Paciente </option>
                                {
                                    listaPacientes.map((tema) => {
                                        return (
                                            <option key={tema.idPaciente} value={tema.idPaciente}>
                                                {tema.nomePaciente}
                                            </option>
                                        );
                                    })}
                            </select>
                            <input type="datetime-local" name="DataConsulta" defaultValue={dataConsulta} onChange={(campo) => setDataConsulta(campo.target.value)} required />
                            <select name="medico" defaultValue={idMedico} onChange={(campo) => setIdMedico(campo.target.value)} className="selects" required>
                                <option value="0" selected disabled>
                                    Selecione o Medico
                                </option>

                                {listaMedicos.map((tema) => {
                                    return (
                                        <option key={tema.idMedico} value={tema.idMedico}>
                                            {tema.nomeMed}
                                        </option>
                                    );
                                })}
                            </select>
                            <select name="situacao" defaultValue={idSituacao} onChange={(campo) => setIdSituacao(campo.target.value)} className="selects" required>
                                <option value="0" selected disabled>Selecione a Situação</option>
                                <option value="1">Agendada</option>
                                <option value="2">Realizada</option>
                                <option value="3">Cancelada</option>

                                
                            </select>
                            <input type="text" placeholder="Descrição" name="descricao" value={descricao} onChange={(campo) => setDescricao(campo.target.value)} required />

                            <button type="submit" className="btn_home">Cadastrar</button>
                        </form>
                    </div>
                </div>
            </main>

            <footer>
                <div className="container container_footer">
                    <span className="span_footer">
                        SPMEDICAL - Todos os direitos reservados
                    </span>
                    <span className="span_footer">
                        Os médicos da Central de Consultas são especialistas.
                    </span>
                </div>
            </footer>
        </div>
    )
}