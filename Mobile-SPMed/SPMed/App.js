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
  Image,
} from 'react-native';

import {
  Colors,
  DebugInstructions,
  Header,
  LearnMoreLinks,
  ReloadInstructions,
} from 'react-native/Libraries/NewAppScreen';

import Perfil from './src/screens/Perfil';
import Lista from './src/screens/Lista';


//navigation
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
const bottomTab = createBottomTabNavigator();
import { NavigationContainer } from '@react-navigation/native';


import api from './src/services/api';
import AsyncStorage from '@react-native-async-storage/async-storage';


class Main extends Component {
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
        '/presenca/Consultas' + idconsulta,
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
        <StatusBar 
          hidden={true}
        />


      <NavigationContainer>
        {/* HEADER */}
        <View style={styles.mainHeader}>
          <Text style={styles.mainHeaderText}>{"Consultas".toUpperCase()}</Text>
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

        <bottomTab.Navigator
        initialRouteName='Lista'

        // versão 5.x do React Navigation
        // tabBarOptions={{
          //   showLabel: false,
        //   showIcon: true,
        //   activeBackgroundColor: '#B727FF',
        //   inactiveBackgroundColor: '#DD99FF',
        //   activeTintColor: 'red',
        //   inactiveTintColor: 'blue',
        //   style: { height: 50 }
        // }}
        
        screenOptions={ ({ route }) => ({
          tabBarIcon: () => {
            
            if (route.name === 'Lista') {
              return(
                <Image
                  source={require('./assets/img/listados.png')}
                  style={styles.tabBarIcon}
                />
              )
            }
            if (route.name === 'Perfil') {
              return(
                <Image
                  source={require('./assets/img/logo-login.png')}
                  style={styles.tabBarIcon}
                />
              )
            }
          },

           // React Navigation 6.x
           headerShown: false,
           tabBarShowLabel: false,
           tabBarActiveBackgroundColor: '#C3EBFA',
           tabBarInactiveBackgroundColor: '#E0F5FD',
           // tabBarActiveTintColor: 'blue',
           // tabBarInactiveTintColor: 'red',
           tabBarStyle: { height: 80 }              
         }) }
       >
         <bottomTab.Screen name="Lista" component={Lista} />
         <bottomTab.Screen name="Perfil" component={Perfil} />
       </bottomTab.Navigator>  
       
        </NavigationContainer>




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
  main: {
    flex: 1,
    backgroundColor: '#F4F8FF',

  },
  mainHeader: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center'
  },

  mainHeaderText: {
    fontSize: 20,
    letterSpacing: 5,
    color: "#A8A8A8",
  },

  mainHeaderLine: {
    width: 231,
    paddingTop: 10,
    borderBottomColor: '#A8A8A8',
    borderBottomWidth: 1
  },

  mainBody: {
    flex: 4,
  },

  mainBodyContent: {
    paddingTop: 30,
    paddingRight: 50,
    paddingLeft: 50,
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

export default Main;
