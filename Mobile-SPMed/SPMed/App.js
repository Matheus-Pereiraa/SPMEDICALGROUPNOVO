import 'react-native-gesture-handler';

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
  TouchableOpacity,
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
import { createStackNavigator } from '@react-navigation/stack';


import api from './src/services/api';
import AsyncStorage from '@react-native-async-storage/async-storage';

import Login from './src/screens/Login';
import Main from './src/screens/main';

const AuthStack = createStackNavigator();


class App extends Component {


  render() {
    return (
      <View style={styles.main}>
        <StatusBar
          hidden={true}
        />


        <NavigationContainer>

          <AuthStack.Navigator>
            <AuthStack.Screen name='Login' component={Login}/>
            <AuthStack.Screen name='Main' component={Main}/>

          </AuthStack.Navigator>

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

export default App;
