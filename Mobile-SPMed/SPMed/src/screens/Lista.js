import React, { Component } from 'react';
import {
  FlatList,
  StyleSheet,
  Text,
  View,
} from 'react-native';

import api from '../services/api';
import AsyncStorage from '@react-native-async-storage/async-storage';


class Lista extends Component {
  constructor(props) {
    super(props);
    this.state = {
      ListaMedico: [],
    };
  }

  BuscaConsulta = async () => {
    try {
      const token = await AsyncStorage.getItem('userToken');
      const resposta = await api.get('/Consulta/minhas', {
        headers: {
          Authorization: 'Bearer ' + token,
        },

      });
      console.warn()
      console.warn(resposta)
      if (resposta.status === 200) {
        const dadoDaApi = resposta.data;
        this.setState({ ListaMedico: dadoDaApi })
        // console.warn(this.state.ListaMedico)
      }


    } catch (error) {
      console.warn(error);
    }
  };


  componentDidMount() {
    this.BuscaConsulta();
  }


  render() {
    return (
      <View style={styles.main}>


        {/* HEADER */}
        <View style={styles.mainHeader}>
          <Text style={styles.mainHeaderText}>{"Consultas".toUpperCase()}</Text>
          <View style={styles.mainHeaderLine} />
        </View>

        <FlatList
          contentContainerStyle={styles.mainBodyContent}
          data={this.state.ListaMedico}
          keyExtractor={item => item.idConsulta}
          renderItem={this.renderItem}
        />
      </View>

    );
  };

  renderItem = ({ item }) => (

    

    <View style={styles.flatItemLinhas}>
      <View style={styles.flatItemContainer}>
        <View style={styles.boxContainer}>
          <Text styles={styles.flatItemTittle}>Data</Text>
          <Text style={styles.flatItemInfo}>
            {Intl.DateTimeFormat("pt-BR", {
              year: 'numeric', month: 'numeric', day: 'numeric',
              hour: 'numeric', minute: 'numeric',
              hour12: true
            }).format(new Date(item.dataeHora))} </Text>

          <Text style={styles.flatItemTittle}>Descrição</Text>
          <Text style={styles.flatItemInfo}>{item.descricao}</Text>
          <Text style={styles.flatItemTittle}>Situação</Text>
          <Text style={styles.flatItemInfo}>{item.idSituacaoNavigation.descricao}</Text>

          <Text style={styles.flatItemTittle}>MÉDICO</Text>
          <Text style={styles.flatItemInfo}>{item.idMedicoNavigation.IdUsuarioNavigation}</Text>
          <Text style={styles.flatItemTittle}>Especialidade</Text>
          <Text style={styles.flatItemInfo}>{item.idMedicoNavigation.idEspecialidadeNavigation.descricao}</Text>
        </View>

      </View>
    </View>
  )
};


const styles = StyleSheet.create({

  boxContainer: {
    alignItems: 'center',
  },

  mainHeader: {
    justifyContent: 'center',
    alignItems: 'center'
  },

  mainHeaderText: {
    fontSize: 20,
    letterSpacing: 5,
    color: "#A8A8A8",
    marginTop: 60
  },

  mainHeaderLine: {
    width: 231,
    paddingTop: 10,
    borderBottomColor: '#A8A8A8',
    borderBottomWidth: 1
  },

  flatItemLinhas: {
    flexDirection: 'row',
    borderBottomWidth: 1,
    borderBottomColor: '#ccc',
    marginTop: 40,
  },
  flatItemContainer: {
    flex: 1,
  },
  flatItemTitle: {
    fontSize: 20,
    color: '#606060',
  },
  flatItemInfo: {
    fontSize: 15,
    color: '#9D9D9D',
    lineHeight: 24,
  },
});

export default Lista;
