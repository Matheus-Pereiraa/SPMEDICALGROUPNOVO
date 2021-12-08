import React, { Component } from 'react';
import {
  FlatList,
  StatusBar,
  StyleSheet,
  Text,
  View,
  Image,
} from 'react-native';

import api from '../services/api';
import {TouchableOpacity} from 'react-native-gesture-handler';
import Perfil from './Perfil'
import Lista from './Lista'


import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
const bottomTab = createBottomTabNavigator();
import { NavigationContainer } from '@react-navigation/native';


import AsyncStorage from '@react-native-async-storage/async-storage';


class Main extends Component {
  


  render() {
    return (
      <View style={styles.main}>
        <StatusBar
          hidden={true}
        />


       

          <bottomTab.Navigator
            initialRouteName='Lista'

            
            screenOptions={({ route }) => ({
              tabBarIcon: () => {

                if (route.name === 'Lista') {
                  return (
                    <Image
                      source={require('../../assets/img/listados.png')}
                      style={styles.tabBarIcon}
                    />
                  )
                }
                if (route.name === 'Perfil') {
                  return (
                    <Image
                      source={require('../../assets/img/logo-login.png')}
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
              tabBarStyle: { height: 80 }
            })}
          >
            <bottomTab.Screen name="Lista" component={Lista} />
            <bottomTab.Screen name="Perfil" component={Perfil} />

          </bottomTab.Navigator>

        



      </View>



    );
  };
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
