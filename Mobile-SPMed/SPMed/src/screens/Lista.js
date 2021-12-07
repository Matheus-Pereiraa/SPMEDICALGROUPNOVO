import React, { Component } from 'react';
import {
  FlatList,
  SafeAreaView,
  ScrollView,
  StatusBar,
  StyleSheet,
  Text,
  useColorScheme,
  View,
} from 'react-native';

import {
  Colors,
  DebugInstructions,
  Header,
  LearnMoreLinks,
  ReloadInstructions,
} from 'react-native/Libraries/NewAppScreen';

import Perfil from './Perfil';


//navigation
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
const bottomTab = createBottomTabNavigator();
import { NavigationContainer } from '@react-navigation/native';


import api from '../services/api';
import AsyncStorage from '@react-native-async-storage/async-storage';


class Lista extends Component {
  constructor(props) {
    super(props);
    this.state = {
      ListaConsulta: []
    };
  };

  inscrever = async idConsulta => {
    try {
      const token = await AsyncStorage.getItem('userToken');

      console.warn(idConsulta);

      await api.post(
        '/api/Consultas' + idconsulta,
        {},
        {
          headers: {
            Authorization: 'Bearer ' + token,
          },
        },
      );
    } catch (error) {
      console.warn(error);
    }
  };



  BuscarConsulta = async () => {
    const resposta = await api.get('/Consultas');
    const dadoDaApi = resposta.data;
    this.setState({ ListaConsulta: dadoDaApi })
  }


  render() {
    return (
      <View style={styles.main}>

        








        {/* HEADER */}
        <View style={styles.mainHeader}>
          <Text style={styles.mainHeaderText}>{"".toUpperCase()}</Text>
          <View style={styles.mainHeaderLine} />
        </View>

        <View style={styles.mainBody}>
          <FlatList
            contentContainerStyle={styles.mainBodyContent}
            data={this.state.ListaConsulta}
            keyExtractor={item => item.idConsulta}
            renderItem={this.renderItem}
          />

        </View>


      </View>



    );
  };

  renderItem = ({ item }) => (
    <View style={styles.flatItemLinhas}>
      <View style={styles.flatItemContainer}>
        <Text styles={styles.flatItemTittle}>{item.idPaciente}</Text>
        <Text styles={styles.flatItemInfo}>{item.Descricao}</Text>
        <Text style={styles.flatItemInfo}>{item.DataeHora}</Text>
      </View>
    </View>
  )
};


const styles = StyleSheet.create({

});

export default Lista;
