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

      if (resposta.status === 200) {
        const dadoDaApi = resposta.data;
        this.setState({ ListaMedico: dadoDaApi })
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


        <Text style={styles.flatItemInfo}>
          {Intl.DateTimeFormat("pt-BR", {
            year: 'numeric', month: 'numeric', day: 'numeric',
            hour: 'numeric', minute: 'numeric',
            hour12: true
          }).format(new Date(item.dataEvento))}
        </Text>
      </View>
    </View>
  )
};


const styles = StyleSheet.create({

});

export default Lista;
